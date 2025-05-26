using CPMS.OcppProxy.Services.Interfaces;

namespace CPMS.OcppProxy.Services.Implementations;

public class MessageQueueService : IMessageQueueService
{
    private readonly Dictionary<string, OCPPMessage> _requestQueue;

    public MessageQueueService()
    {
        _requestQueue = new Dictionary<string, OCPPMessage>();
    }

    public Dictionary<string, OCPPMessage> RequestQueue => _requestQueue;

    public void AddOrUpdateRequest(string id, OCPPMessage message)
    {
        lock (_requestQueue)
        {
            _requestQueue[id] = message;
        }
    }

    public bool TryGetRequest(string id, out OCPPMessage message)
    {
        lock (_requestQueue)
        {
            return _requestQueue.TryGetValue(id, out message);
        }
    }

    public bool RemoveRequest(string id)
    {
        lock (_requestQueue)
        {
            return _requestQueue.Remove(id);
        }
    }
}
