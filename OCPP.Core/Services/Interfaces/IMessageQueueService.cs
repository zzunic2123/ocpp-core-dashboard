namespace CPMS.OcppProxy.Services.Interfaces;

public interface IMessageQueueService
{
    void AddOrUpdateRequest(string id, OCPPMessage message);
    bool TryGetRequest(string id, out OCPPMessage message);
    bool RemoveRequest(string id);
}