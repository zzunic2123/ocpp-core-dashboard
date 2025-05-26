using System.Net;
using System.Net.WebSockets;
using System.Text;
using CPMS.OcppProxy.Services.Interfaces;
using CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;

namespace CPMS.OcppProxy.Services.Implementations;

public class OcppMiddlewareService : IOCPPMiddlewareService
{

        private static readonly string[] SupportedProtocols = { ChargePointStatus.Protocol_OCPP16, ChargePointStatus.Protocol_OCPP201 /*, "ocpp1.5" */};

        // RegExp for splitting ocpp message parts
        // ^\[\s*(\d)\s*,\s*\"([^"]*)\"\s*,(?:\s*\"(\w*)\"\s*,)?\s*(.*)\s*\]$
        // Third block is optional, because responses don't have an action
        private static string MessageRegExp = "^\\[\\s*(\\d)\\s*,\\s*\"([^\"]*)\"\\s*,(?:\\s*\"(\\w*)\"\\s*,)?\\s*(.*)\\s*\\]$";

        private readonly IConfiguration _configuration;
        private readonly IOCPP16StateManager _ocpp16StateManager;
        private readonly IChargerService _chargerService;
        
        // Dictionary with status objects for each charge point
        private readonly IChargePointStatusService _chargePointStatusDict;
        // Dictionary for processing asynchronous API calls

        public OcppMiddlewareService(
            IConfiguration configuration, 
            IChargePointStatusService chargePointStatusDict, 
            IOCPP16StateManager ocpp16StateManager, 
            IChargerService chargerService)
        {
            _configuration = configuration;
            _chargePointStatusDict = chargePointStatusDict;
            _ocpp16StateManager = ocpp16StateManager;
            _chargerService = chargerService;
        }


        public async Task HandleRootRequest(HttpContext context)
        {
            try
            {
                bool showIndexInfo = _configuration.GetValue<bool>("ShowIndexInfo");
                if (showIndexInfo)
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(string.Format("Running...\r\n\r\n{0} chargepoints connected\r\n\r\nApi health response: \"{1}\"", _chargePointStatusDict.GetChargePointStatusCount(), StatusCodes.Status200OK));
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception exp)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }

        public async Task HandleOCPPRequest(HttpContext context)
        {
            string chargepointIdentifier = GetChargepointIdentifierFromPath(context.Request.Path.Value);
            
            if (string.IsNullOrWhiteSpace(chargepointIdentifier))
            {
                context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                return;
            }

            
            ChargePointStatus? chargePointStatus = await RetrieveChargePointStatus(chargepointIdentifier);

            if (chargePointStatus == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                return;
            }
            
            await InitiateWebSocketConnection(context, chargePointStatus, chargepointIdentifier);
        }

        #region HandleOCPPRequestHelpers

        private async Task<ChargePointStatus?> RetrieveChargePointStatus(string identifier)
        {
            var chargePoint = await _chargerService.GetChargerByOcppChargerId(identifier);
            if (chargePoint != null)
            {
                return new ChargePointStatus(chargePoint.OcppChargerId);
            }
            return null;
        }

        private async Task InitiateWebSocketConnection(HttpContext context, ChargePointStatus chargePointStatus, string identifier)
        {
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            var subProtocol = DetermineSubProtocol(context);

            if (!await AuthenticateChargePoint(context, identifier))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            if (string.IsNullOrEmpty(subProtocol))
            {
                string protocols = string.Empty;
                foreach (string p in context.WebSockets.WebSocketRequestedProtocols)
                {
                    if (string.IsNullOrEmpty(protocols)) protocols += ",";
                    protocols += p;
                }
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return;
            }

            chargePointStatus.Protocol = subProtocol;
            if (await CreateChargePointStatus(identifier, chargePointStatus, context))
            {
                await ProcessWebSocketMessages(context, chargePointStatus, subProtocol, identifier);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }

        #region HTTPBasicAuthentication

        private async Task<bool> AuthenticateChargePoint(HttpContext context, string identifier)
        {
            
            // logic for EnergAI testing with schneider Charger
            var chargePoint = await _chargerService.GetChargerByOcppChargerId(identifier);

            if (chargePoint.Password == null) 
                return true;
            
            // Http Basic Authentication
            string encodedCredentials = GetEncodedCredentials(context);
            
            if (string.IsNullOrEmpty(encodedCredentials))
            {
                
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return false;
            }

            
            (string username, string password) = DecodeCredentials(encodedCredentials);

            
            bool credentialsValid = await _chargerService.CheckChargerCredentials(identifier, password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || !credentialsValid)
            {
                
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return false;
            }

            
            return true;
        }

        private (string usr, string pass) DecodeCredentials(string encodedCredentials)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string decodedCredentials = encoding.GetString(Convert.FromBase64String(encodedCredentials));
            int separatorIndex = decodedCredentials.IndexOf(':');
            if (separatorIndex == -1)
            {
                return (null,null);
            }
            
            string username = decodedCredentials.Substring(0, separatorIndex);
            string password = decodedCredentials.Substring(separatorIndex + 1);
            
            return (username, password);
        }

        private string GetEncodedCredentials(HttpContext context)
        {
            string encodedCredentials = null;
            if (context.WebSockets.WebSocketRequestedProtocols.Contains("simulator") && context.Request.QueryString.HasValue)
            {
                var queryParams = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(context.Request.QueryString.Value);
                encodedCredentials = queryParams["auth"];
            }
            else if (context.Request.Headers.TryGetValue("Authorization", out var authHeader) && authHeader.ToString().StartsWith("Basic"))
            {
                encodedCredentials = authHeader.ToString().Substring("Basic ".Length).Trim();
            }

            return encodedCredentials;
        }

        #endregion

        private async Task ProcessWebSocketMessages(HttpContext context, ChargePointStatus chargePointStatus, string subProtocol, string chargepointIdentifier)
        {
            // Handle socket communicatioN

            using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync(subProtocol))
            {
                
                chargePointStatus.WebSocket = webSocket;
                

                    await _ocpp16StateManager.ReceiveMessages(chargePointStatus, context);
                
            }
        }

        private async Task<bool> CreateChargePointStatus(string chargepointIdentifier, ChargePointStatus chargePointStatus, HttpContext context)
        {
            bool statusSuccess = false;
            try
            {
                


                    
                // Check if this chargepoint already/still hat a status object
                if (_chargePointStatusDict.TryGetChargePointStatus(chargepointIdentifier, out ChargePointStatus status))
                {
                    
                    // Closed or aborted => remove
                    _chargePointStatusDict.RemoveChargePointStatus(chargepointIdentifier);
                }
                    
                
                _chargePointStatusDict.AddOrUpdateChargePointStatus(chargepointIdentifier, chargePointStatus);

                ChargerDto chargerDto = new ChargerDto();
                chargerDto.OcppChargerId = chargePointStatus.Id;
                chargerDto.OnlineStatus = true;
                chargerDto.OcppVersion = chargePointStatus.Protocol;
        
                await _chargerService.UpdateCharger(chargerDto);
                    
                statusSuccess = true;
                
            }
            catch(Exception exp)
            {
                
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return statusSuccess;
        }

        private string DetermineSubProtocol(HttpContext context)
        {
            foreach (string supportedProtocol in SupportedProtocols)
            {
                if (context.WebSockets.WebSocketRequestedProtocols.Contains(supportedProtocol))
                    return supportedProtocol;
            }
            return null;
        }

        private string GetChargepointIdentifierFromPath(string path)
        {
            var parts = path.Split('/');
            var lastPart = parts[parts.Length - 1];
            return string.IsNullOrWhiteSpace(lastPart) ? parts[parts.Length - 2] : lastPart;
        }

        #endregion
    
}

