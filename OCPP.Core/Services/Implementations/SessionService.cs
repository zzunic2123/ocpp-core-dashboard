using CPMS.OcppProxy.Data.Entities;

namespace CPMS.OcppProxy.Services.Implementations;

public interface ISessionService
{
    int StartSession(ChargingSession session);
    void UpdateSession(int transactionId, Action<ChargingSession> update);
    ChargingSession? GetSession(int transactionId);
    IEnumerable<ChargingSession> GetAllSessions();
    void StopSession(int transactionId);
}


public class SessionService : ISessionService
{
    private readonly Dictionary<int, ChargingSession> _sessions = new();
    private int _transactionIdCounter = 1;

    private int GenerateTransactionId()
    {
        return Interlocked.Increment(ref _transactionIdCounter);
    }

    public int StartSession(ChargingSession session)
    {
        int transactionId = GenerateTransactionId();
        session.Id = transactionId;
        _sessions[transactionId] = session;
        return transactionId;
    }

    public void UpdateSession(int transactionId, Action<ChargingSession> update)
    {
        if (_sessions.TryGetValue(transactionId, out var session))
        {
            update(session);
        }
    }
    
    public IEnumerable<ChargingSession> GetAllSessions() // ← Implementation
    {
        return _sessions.Values;
    }

    public ChargingSession? GetSession(int transactionId)
    {
        _sessions.TryGetValue(transactionId, out var session);
        return session;
    }

    public void StopSession(int transactionId)
    {
        _sessions.Remove(transactionId);
    }
}

