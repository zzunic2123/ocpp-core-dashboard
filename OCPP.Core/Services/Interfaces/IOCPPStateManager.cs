namespace CPMS.OcppProxy.Services.Interfaces;

public interface IOCPPStateManager
{
    Task ReceiveMessages(ChargePointStatus chargePointStatus, HttpContext context);
}