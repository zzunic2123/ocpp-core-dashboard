using CPMS.Shared.Messages_OCPP16;
using Utf8Json;

namespace CPMS.OcppProxy.Controllers.Controllers_OCPP16
{
    public partial class BaseControllerOcpp16
    {
        public string HandleHeartBeat(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            string errorCode = null;

            HeartbeatResponse heartbeatResponse = new HeartbeatResponse();
            heartbeatResponse.CurrentTime = DateTimeOffset.UtcNow;

            msgOut.JsonPayload = JsonSerializer.ToJsonString(heartbeatResponse);

            return errorCode;
        }
    }
}
