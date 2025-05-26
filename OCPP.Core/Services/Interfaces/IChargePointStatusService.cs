namespace CPMS.OcppProxy.Services.Interfaces;

public interface IChargePointStatusService
{
    void AddOrUpdateChargePointStatus(string id, ChargePointStatus status);
    bool TryGetChargePointStatus(string id, out ChargePointStatus? status);
    bool RemoveChargePointStatus(string id);
    int GetChargePointStatusCount();
}