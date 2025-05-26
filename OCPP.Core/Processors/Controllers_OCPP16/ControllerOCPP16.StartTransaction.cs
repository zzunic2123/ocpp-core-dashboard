using CPMS.OcppProxy.Data.Entities;
using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;
using CPMS.Shared.Messages_OCPP16;
using Utf8Json;
using AuthorizationStatus = CPMS.Shared.Messages_OCPP16.AuthorizationStatus;
using StartTransactionResponse = CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ProxyResponse.StartTransactionResponse;
using StartTransactionResponseProxy = CPMS.Shared.Messages_OCPP16.StartTransactionResponse;

namespace CPMS.OcppProxy.Controllers.Controllers_OCPP16
{
    public partial class BaseControllerOcpp16
    {
        public async Task<string> HandleStartTransaction(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            string errorCode = null;
            try
            {
                
                StartTransactionRequest startTransactionRequest = JsonSerializer.Deserialize<StartTransactionRequest>(msgIn.JsonPayload);
                
                StartTransactionChargerResponse startTransaction = new();
                startTransaction.OcppChargerId = ChargePointStatus.Id;
                startTransaction.OcppConnectorId = startTransactionRequest.ConnectorId;
                startTransaction.OcppEvseId = 0;
                startTransaction.TimeStart = startTransactionRequest.Timestamp.UtcDateTime;
                startTransaction.MeterStart = (double)startTransactionRequest.MeterStart / 1000;
                startTransaction.IdTag = startTransactionRequest.IdTag;
                
                
                var session = new ChargingSession
                {
                    OcppChargerId = ChargePointStatus.Id,
                    ConnectorId = startTransactionRequest.ConnectorId,
                    TimeStart = startTransactionRequest.Timestamp.UtcDateTime,
                    MeterStart = startTransactionRequest.MeterStart / 1000.0,
                    IdTag = startTransactionRequest.IdTag
                };

                int transactionId = _sessionService.StartSession(session);

                var response = new StartTransactionResponseProxy()
                {
                    TransactionId = transactionId,
                    IdTagInfo = new IdTagInfo
                    {
                        Status = AuthorizationStatus.Accepted,
                        ExpiryDate = DateTime.UtcNow.AddHours(2)
                    }
                };

                msgOut.JsonPayload = JsonSerializer.ToJsonString(response);
                
            }
            catch (Exception exp)
            {
                
                errorCode = ErrorCodes.FormationViolation;
            }

            return errorCode;
        }
    }
}
