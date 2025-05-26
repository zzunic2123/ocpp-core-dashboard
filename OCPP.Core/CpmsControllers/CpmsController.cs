using CPMS.OcppProxy.Data.Entities;
using CPMS.OcppProxy.Services.Implementations;
using CPMS.OcppProxy.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.OcppProxy.CpmsControllers;

[Route("api/Cpms/[action]")]
[ApiController]
public class CpmsController : ControllerBase
{
    private readonly ISessionService _sessionService;
    private readonly IChargerService _chargerService;

    public CpmsController(IChargerService chargerService, ISessionService sessionService)
    {
        _chargerService = chargerService;
        _sessionService = sessionService;
    }

    // 🔌 Get all known chargers (including active and deleted)
    [HttpGet]
    public async Task<IEnumerable<Charger>> GetAllChargers()
    {
        var result = await _chargerService.GetAllChargers();
        return result;
    }

    // 📡 Get all active charging sessions
    [HttpGet]
    public IEnumerable<ChargingSession> GetAllSessions()
    {
        return _sessionService.GetAllSessions();
    }
}