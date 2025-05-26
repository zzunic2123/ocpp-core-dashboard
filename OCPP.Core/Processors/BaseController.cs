using CPMS.OcppProxy.Chargers.Interfaces;
using CPMS.OcppProxy.Services.Interfaces;
using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;
using CPMS.Shared.Messages_OCPP16;
using KeyValue = CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest.KeyValue;

namespace CPMS.OcppProxy.Controllers
{
    public abstract class BaseController : IController
    {
        protected IConfiguration Configuration { get; set; }
        protected ChargePointStatus ChargePointStatus { get; set; }
        protected readonly IChargerV16 _chargerV16;
        protected readonly IChargerService _chargerService;


        public BaseController(
            IConfiguration config,
            ChargePointStatus chargePointStatus,
            IChargerV16 chargerV16,
            IChargerService chargerService)
        {
            _chargerV16 = chargerV16;
            _chargerService = chargerService;
            Configuration = config;

            if (chargePointStatus != null)
            {
                ChargePointStatus = chargePointStatus;
            }
        }

        public abstract Task<OCPPMessage> ProcessRequest(OCPPMessage msgIn);
        public abstract Task ProcessAnswer(OCPPMessage msgIn, OCPPMessage msgOut);
        
    }
}
