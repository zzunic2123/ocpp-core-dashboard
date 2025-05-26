using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using CPMS.OcppProxy.Chargers.Interfaces;
using CPMS.OcppProxy.Services.Interfaces;
using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;
using CPMS.Shared.Messages_OCPP16;
using Newtonsoft.Json;
using ResetRequest = CPMS.Shared.Messages_OCPP16.ResetRequest;
using ResetType = CPMS.Shared.Messages_OCPP16.ResetType;

namespace CPMS.OcppProxy.Chargers.Implementations;

public class ChargerV16 : IChargerV16
{
    private readonly IMessageQueueService _messageQueueService;

    public ChargerV16(
        IMessageQueueService messageQueueService)
    {
        _messageQueueService = messageQueueService;
    }

    public async Task<string> ResetCharger(ChargePointStatus chargePointStatus, ResetDto resetDto)
    {
        ResetRequest resetRequest = new ResetRequest();
        resetRequest.Type = resetDto.Type == Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest.ResetType.Hard ? ResetType.Hard : ResetType.Soft;
        string jsonResetRequest = JsonConvert.ToString(resetDto);
        
        OCPPMessage msgOut = new OCPPMessage();
        msgOut.MessageId = Guid.NewGuid().ToString();
        msgOut.MessageType = "2";
        msgOut.Action = "Reset";
        msgOut.UniqueId = Guid.NewGuid().ToString("N");
        msgOut.JsonPayload = jsonResetRequest;
        msgOut.TaskCompletionSource = new TaskCompletionSource<string>();

        _messageQueueService.AddOrUpdateRequest(msgOut.UniqueId, msgOut);
        await SendOcppMessage(msgOut, chargePointStatus);
        
        return "";
    }
    public async Task<string> RemoteStop(ChargePointStatus chargePointStatus, RemoteStopTransactionDto remoteStopTransactionDto)
    {
        RemoteStopTransactionRequest resetRequest = new();
        resetRequest.TransactionId = remoteStopTransactionDto.TransactionId;

        string jsonResetRequest = JsonConvert.ToString(resetRequest);

        OCPPMessage msgOut = new OCPPMessage();
        msgOut.MessageId = Guid.NewGuid().ToString();
        msgOut.MessageType = "2";
        msgOut.Action = "RemoteStopTransaction";
        msgOut.UniqueId = Guid.NewGuid().ToString("N");
        msgOut.JsonPayload = jsonResetRequest;
        msgOut.TaskCompletionSource = new TaskCompletionSource<string>();
        
        _messageQueueService.AddOrUpdateRequest(msgOut.UniqueId, msgOut);
        await SendOcppMessage(msgOut, chargePointStatus);
        
        return "";
    }

    public async Task<string> RemoteStart(ChargePointStatus chargePointStatus, RemoteStartTransactionDto remoteStartTransactionDto)
    {
        RemoteStartTransactionRequest remoteStartRequest = new ();
        remoteStartRequest.IdTag = remoteStartTransactionDto.IdTag;
        remoteStartRequest.ConnectorId = remoteStartTransactionDto.ConnectorId;
        string jsonRemoteStartRequest = JsonConvert.ToString(remoteStartRequest);

        OCPPMessage msgOut = new OCPPMessage();
        msgOut.MessageId = Guid.NewGuid().ToString();
        msgOut.MessageType = "2";
        msgOut.Action = "RemoteStartTransaction";
        msgOut.UniqueId = Guid.NewGuid().ToString("N");
        msgOut.JsonPayload = jsonRemoteStartRequest;
        msgOut.TaskCompletionSource = new TaskCompletionSource<string>();
        
        _messageQueueService.AddOrUpdateRequest(msgOut.UniqueId, msgOut);
        await SendOcppMessage(msgOut, chargePointStatus);
        return "";
    }
    
    

    // kafka action is used when sending CPMS response message to Worker via kafka, so in Logs database we have Action in CPMS response message to match request message
    public async Task SendOcppMessage(OCPPMessage msg, ChargePointStatus chargePointStatus, string? kafkaAction = null)
    {
            string ocppTextMessage = null;

            if (string.IsNullOrEmpty(msg.ErrorCode))
            {
                if (msg.MessageType == "2")
                {
                    // OCPP-Request
                    ocppTextMessage = string.Format("[{0},\"{1}\",\"{2}\",{3}]", msg.MessageType, msg.UniqueId, msg.Action, msg.JsonPayload);
                }
                else
                {
                    // OCPP-Response
                    ocppTextMessage = string.Format("[{0},\"{1}\",{2}]", msg.MessageType, msg.UniqueId, msg.JsonPayload);
                }
            }
            else
            {
                ocppTextMessage = string.Format("[{0},\"{1}\",\"{2}\",\"{3}\",{4}]", msg.MessageType, msg.UniqueId, msg.ErrorCode, msg.ErrorDescription, "{}");
            }

            if (string.IsNullOrEmpty(ocppTextMessage))
            {
                // invalid message
                ocppTextMessage = string.Format("[{0},\"{1}\",\"{2}\",\"{3}\",{4}]", "4", string.Empty, ErrorCodes.ProtocolError, string.Empty, "{}");
            }
            
            byte[] binaryMessage = Encoding.UTF8.GetBytes(ocppTextMessage);
            await chargePointStatus.WebSocket.SendAsync(new ArraySegment<byte>(binaryMessage, 0, binaryMessage.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            
    }
}