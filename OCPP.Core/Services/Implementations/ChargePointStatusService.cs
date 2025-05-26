using CPMS.OcppProxy.Services.Interfaces;

namespace CPMS.OcppProxy.Services.Implementations;

public class ChargePointStatusService : IChargePointStatusService
{
    private readonly Dictionary<string, ChargePointStatus> _chargePointStatusDict;

    public ChargePointStatusService()
    {
        _chargePointStatusDict = new Dictionary<string, ChargePointStatus>();
    }

    public Dictionary<string, ChargePointStatus> ChargePointStatusDict => _chargePointStatusDict;

    public void AddOrUpdateChargePointStatus(string id, ChargePointStatus status)
    {
        lock (_chargePointStatusDict)
        {
            _chargePointStatusDict[id] = status;
        }
    }

    public bool TryGetChargePointStatus(string id, out ChargePointStatus? status)
    {
        lock (_chargePointStatusDict)
        {
            return _chargePointStatusDict.TryGetValue(id, out status);
        }
    }

    public bool RemoveChargePointStatus(string id)
    {
        lock (_chargePointStatusDict)
        {
            return _chargePointStatusDict.Remove(id);
        }
    }
    
    public int GetChargePointStatusCount()
    {
        lock (_chargePointStatusDict)
        {
            return _chargePointStatusDict.Count;
        }
    }   
}
