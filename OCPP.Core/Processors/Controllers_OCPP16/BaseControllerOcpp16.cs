using CPMS.OcppProxy.Chargers.Interfaces;
using CPMS.OcppProxy.Services.Implementations;
using CPMS.OcppProxy.Services.Interfaces;
using CPMS.Shared.Messages_OCPP16;

namespace CPMS.OcppProxy.Controllers.Controllers_OCPP16
{
    public partial class BaseControllerOcpp16 : BaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        private readonly ISessionService _sessionService;

        public BaseControllerOcpp16(
            IConfiguration config,
            ChargePointStatus chargePointStatus, 
            IChargerV16 chargerV16, 
            IChargerService chargerService,
            ISessionService sessionService) :
            base(config, chargePointStatus, chargerV16, chargerService)
        {
            _sessionService = sessionService;

        }

        /// <summary>
        /// Processes the charge point message and returns the answer message
        /// </summary>
        public override async Task<OCPPMessage> ProcessRequest(OCPPMessage msgIn)
        {
            OCPPMessage msgOut = new OCPPMessage();
            msgOut.MessageType = "3";
            msgOut.UniqueId = msgIn.UniqueId;

            string errorCode = null;

            switch (msgIn.Action)
            {
                case "BootNotification":
                    errorCode = await HandleBootNotification(msgIn, msgOut);
                    break;

                case "Heartbeat":
                    errorCode = HandleHeartBeat(msgIn, msgOut);
                    break;

                case "StartTransaction":
                    errorCode = await HandleStartTransaction(msgIn, msgOut);
                    break;

                case "StopTransaction":
                    errorCode = await HandleStopTransaction(msgIn, msgOut);
                    break;

                case "MeterValues":
                    errorCode = await HandleMeterValues(msgIn, msgOut);
                    break;

                case "StatusNotification":
                    errorCode = await HandleStatusNotification(msgIn, msgOut);
                    break;
                
                default:
                    errorCode = ErrorCodes.NotSupported;
                    break;
            }

            if (!string.IsNullOrEmpty(errorCode))
            {
                // Inavlid message type => return type "4" (CALLERROR)
                msgOut.MessageType = "4";
                msgOut.ErrorCode = errorCode;
            }

            return msgOut;
        }


        /// <summary>
        /// Processes the charge point message and returns the answer message
        /// </summary>
        public override async Task ProcessAnswer(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            // The response (msgIn) has no action => check action in original request (msgOut)
            switch (msgOut.Action)
            {
                
                
                default:
                    break;
            }
        }
    }
}
