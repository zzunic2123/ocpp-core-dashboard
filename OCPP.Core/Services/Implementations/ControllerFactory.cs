using CPMS.OcppProxy.Chargers.Interfaces;
using CPMS.OcppProxy.Controllers.Controllers_OCPP16;
using CPMS.OcppProxy.Services.Interfaces;

namespace CPMS.OcppProxy.Services.Implementations;

public class ControllerFactory : IControllerFactory
{
    private readonly IConfiguration _configuration;
    private readonly IChargerV16 _chargerV16;
    private readonly IChargerService _chargerService;
    private readonly ISessionService _sessionService;

    public ControllerFactory(
        IConfiguration configuration,
        IChargerV16 chargerV16,
        IChargerService chargerService,
        ISessionService sessionService)
    {
        _configuration = configuration;
        _chargerV16 = chargerV16;
        _chargerService = chargerService;
        _sessionService = sessionService;
    }

    public BaseControllerOcpp16 CreateOCPP16Controller(ChargePointStatus chargePointStatus)
    {
        return new BaseControllerOcpp16(
            _configuration,
            chargePointStatus,
            _chargerV16,
            _chargerService,
            _sessionService);
    }

}
