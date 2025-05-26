using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;
using CPMS.Shared.Messages_OCPP16;
using Utf8Json;

namespace CPMS.OcppProxy.Controllers.Controllers_OCPP16
{
    public partial class BaseControllerOcpp16
    {
        public async Task<string> HandleStatusNotification(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            string errorCode = null;
            StatusNotificationResponse statusNotificationResponse = new StatusNotificationResponse();

            bool msgWritten = false;

            try
            {
                
                StatusNotificationRequest statusNotificationRequest = JsonSerializer.Deserialize<StatusNotificationRequest>(msgIn.JsonPayload);
                
                
                

                if (statusNotificationRequest.ConnectorId > 0)
                {
                    StatusNotificationChargerRequest statusNotificationChargerRequest =
                        new StatusNotificationChargerRequest();
                    statusNotificationChargerRequest.OcppChargerId = ChargePointStatus.Id;
                    statusNotificationChargerRequest.OcppEvseId = 0;
                    statusNotificationChargerRequest.OcppConnectorId = statusNotificationRequest.ConnectorId;
                    statusNotificationChargerRequest.LastStatus = statusNotificationRequest.Status.ToString();
                    statusNotificationChargerRequest.LastStatusTime = ((statusNotificationRequest.Timestamp.HasValue)
                        ? statusNotificationRequest.Timestamp.Value
                        : DateTimeOffset.UtcNow).DateTime;
                    statusNotificationChargerRequest.ChargerId = ChargePointStatus.Id;
                    statusNotificationChargerRequest.Protocol = ChargePointStatus.Protocol;
                }
                else
                {
                    
                }

                msgOut.JsonPayload = JsonSerializer.ToJsonString(statusNotificationResponse);
                
            }
            catch (Exception exp)
            {
                
                errorCode = ErrorCodes.InternalError;
            }
            
            return errorCode;
        }
    }
}
