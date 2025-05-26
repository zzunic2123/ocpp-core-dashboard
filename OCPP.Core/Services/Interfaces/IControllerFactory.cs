using CPMS.OcppProxy.Controllers.Controllers_OCPP16;

namespace CPMS.OcppProxy.Services.Interfaces;

public interface IControllerFactory
{
    BaseControllerOcpp16 CreateOCPP16Controller(ChargePointStatus chargePointStatus);
}
