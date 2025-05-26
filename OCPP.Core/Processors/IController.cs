namespace CPMS.OcppProxy.Controllers;

public interface IController
{
    Task<OCPPMessage> ProcessRequest(OCPPMessage msgIn);
    Task ProcessAnswer(OCPPMessage msgIn, OCPPMessage msgOut);
}