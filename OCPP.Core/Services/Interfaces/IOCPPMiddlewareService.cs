namespace CPMS.OcppProxy.Services.Interfaces;

public interface IOCPPMiddlewareService
{
    Task HandleOCPPRequest(HttpContext context);
    Task HandleRootRequest(HttpContext context);
}