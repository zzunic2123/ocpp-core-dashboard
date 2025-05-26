using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using CPMS.OcppProxy.Chargers.Interfaces;
using CPMS.OcppProxy.Controllers.Controllers_OCPP16;
using CPMS.OcppProxy.Services.Interfaces;
using CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CPMS.OcppProxy.Services.Implementations;

public interface IOCPP16StateManager : IOCPPStateManager
{
    Task ProcessOCPPMessage(OCPPMessage msgIn, ChargePointStatus chargePointStatus, BaseControllerOcpp16 baseController,
        string ocppMessage);
}

public class OCPP16StateManager : IOCPP16StateManager
{
    private readonly IChargerV16 _chargerV16;
    private readonly IControllerFactory _controllerFactory;
    private readonly IChargerService _chargerService;
    
    private readonly IChargePointStatusService _chargePointStatusService;
    private readonly IMessageQueueService _messageQueueService;
    
    private static readonly string MessageRegExp = "^\\[\\s*(\\d)\\s*,\\s*\"([^\"]*)\"\\s*,(?:\\s*\"(\\w*)\"\\s*,)?\\s*(.*)\\s*\\]$";

    public OCPP16StateManager(
        IChargerV16 chargerV16, 
        IChargePointStatusService chargePointStatusService, 
        IMessageQueueService messageQueueService, 
        IControllerFactory controllerFactory,
        IChargerService chargerService)
    {
        _chargerV16 = chargerV16;
        _chargePointStatusService = chargePointStatusService;
        _messageQueueService = messageQueueService;
        _controllerFactory = controllerFactory;
        _chargerService = chargerService;
    }

    public async Task ReceiveMessages(ChargePointStatus chargePointStatus, HttpContext context)
    {
        BaseControllerOcpp16 controller16 = _controllerFactory.CreateOCPP16Controller(chargePointStatus);

        byte[] buffer = new byte[1024 * 4];
        MemoryStream memStream = new MemoryStream(buffer.Length);

        while (chargePointStatus.WebSocket.State == WebSocketState.Open)
        {
            WebSocketReceiveResult result;
            try
            {
                result = await chargePointStatus.WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
            {
                
                break;
            }
            catch (Exception e)
            {
                
                break;
            }

            if (result.MessageType == WebSocketMessageType.Close)
            {
                
                await chargePointStatus.WebSocket.CloseOutputAsync((WebSocketCloseStatus)3001, string.Empty, CancellationToken.None);
                break;
            }

            
            memStream.Write(buffer, 0, result.Count);

            if (!result.EndOfMessage)
                continue;

            byte[] bMessage = memStream.ToArray();
            memStream = new MemoryStream(buffer.Length);

            string ocppMessage = Encoding.UTF8.GetString(bMessage);
            if (ocppMessage == "ping")
                continue;

            var jsonObject = JsonConvert.DeserializeObject<JArray>(ocppMessage);
            ocppMessage = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            
            Match match = Regex.Match(ocppMessage, MessageRegExp, RegexOptions.Singleline);

            if (match?.Groups == null || match.Groups.Count < 3 || !match.Success)
            {
                
                continue;
            }

            string messageTypeId = match.Groups[1].Value;
            string uniqueId = match.Groups[2].Value;
            string action = match.Groups[3].Value;
            string jsonPaylod = match.Groups[4].Value;

            OCPPMessage msgIn = new OCPPMessage(messageTypeId, uniqueId, action, jsonPaylod);

            await ProcessOCPPMessage(msgIn, chargePointStatus, controller16, ocppMessage);
        }
        

        _chargePointStatusService.RemoveChargePointStatus(chargePointStatus.Id);

        ChargerDto chargerDto = new ChargerDto();
        chargerDto.OcppChargerId = chargePointStatus.Id;
        chargerDto.OnlineStatus = false;
        
        await _chargerService.UpdateCharger(chargerDto);
    }

    public async Task ProcessOCPPMessage(OCPPMessage msgIn, ChargePointStatus chargePointStatus, BaseControllerOcpp16 baseController, string ocppMessage)
    {
        switch (msgIn.MessageType)
        {
            case "2":
                msgIn.MessageId = Guid.NewGuid().ToString();
                
                OCPPMessage responseFromCpms = await baseController.ProcessRequest(msgIn);
                responseFromCpms.MessageId = msgIn.MessageId;
                await _chargerV16.SendOcppMessage(responseFromCpms, chargePointStatus, msgIn.Action);

                break;
            case "3":
            case "4":
                if (_messageQueueService.TryGetRequest(msgIn.UniqueId, out OCPPMessage message))
                {
                    var requestFromCPMS = message;
                    string helper = msgIn.Action;
                    msgIn.Action = requestFromCPMS.Action;
                    msgIn.MessageId = requestFromCPMS.MessageId;
                    
                    msgIn.Action = helper;
                    await baseController.ProcessAnswer(msgIn, requestFromCPMS);
                    _messageQueueService.RemoveRequest(msgIn.UniqueId);
                }
                break;
        }
        
    }
    
}
