using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;
using CPMS.Shared.Messages_OCPP16;

namespace CPMS.OcppProxy.Chargers.Interfaces;

public interface IChargerV16
{
    Task<string> ResetCharger(ChargePointStatus chargePointStatus, ResetDto resetDto);
    Task<string> RemoteStop(ChargePointStatus chargePointStatus, RemoteStopTransactionDto remoteStopTransactionDto);
    Task<string> RemoteStart(ChargePointStatus chargePointStatus, RemoteStartTransactionDto remoteStartTransactionDto);
    Task SendOcppMessage(OCPPMessage msg, ChargePointStatus chargePointStatus, string? kafkaAction = null);
}