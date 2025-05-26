using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;
using CPMS.Shared.Messages_OCPP16;
using Utf8Json;
using AuthorizationStatus = CPMS.Shared.Messages_OCPP16.AuthorizationStatus;
using StopTransactionResponse = CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ProxyResponse.StopTransactionResponse;
using StopTransactionResponseProxy = CPMS.Shared.Messages_OCPP16.StopTransactionResponse;

namespace CPMS.OcppProxy.Controllers.Controllers_OCPP16
{
    public partial class BaseControllerOcpp16
    {
        public async Task<string> HandleStopTransaction(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            string errorCode = null;

            try
            {
                var stopTransactionRequest = JsonSerializer.Deserialize<StopTransactionRequest>(msgIn.JsonPayload);
                var transactionId = stopTransactionRequest.TransactionId;

                // Update the session
                _sessionService.UpdateSession(transactionId, session =>
                {
                    session.TimeStop = stopTransactionRequest.Timestamp.UtcDateTime;
                    session.MeterStop = stopTransactionRequest.MeterStop / 1000.0;
                    session.StopReason = stopTransactionRequest.Reason.ToString();
                });

                // Create and assign the response payload
                var response = new StopTransactionResponseProxy();
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
