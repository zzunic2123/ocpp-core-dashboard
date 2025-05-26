using AutoMapper;
using CPMS.OcppProxy.Data.Entities;
using CPMS.OcppProxy.Services.Interfaces;
using CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;
using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public interface IChargerService
{
    Task AddOrUpdateChargers(AddOrUpdateChargersDto addOrUpdateChargersDto);
    Task<ChargerDto> GetChargerByOcppChargerId(string ocppChargerId);
    Task UpdateCharger(ChargerDto chargerDto);
    Task UpdateChargerEntity(Charger charger);
    Charger GetChargerByOcppChargerIdEntity(string ocppChargerId);
    Task<bool> CheckChargerCredentials(string ocppChargerId, string basicAuthPassword);
    Task DeleteChargers(DeleteChargersDto deleteChargersDto);
    Task<IEnumerable<Charger>> GetAllChargers();

}
public class ChargerService : IChargerService
{
    private readonly IMapper _mapper;

    // Simulated database
    private static readonly Dictionary<string, Charger> _chargers = new Dictionary<string, Charger>{};

    public ChargerService(IMapper mapper)
    {
        _mapper = mapper;
        _chargers.Add("CHGR-0010-HHI08", new Charger{Id = 1, OcppChargerId = "CHGR-0010-HHI08", Password = "Password123", IsDeleted = false});
        _chargers.Add("CHGR-01", new Charger{Id = 1, OcppChargerId = "CHGR-01", Password = "Password123", IsDeleted = false});
        _chargers.Add("CHGR-02", new Charger{Id = 1, OcppChargerId = "CHGR-02", Password = "Password123", IsDeleted = false});
        _chargers.Add("CHGR-03", new Charger{Id = 1, OcppChargerId = "CHGR-03", Password = "Password123", IsDeleted = false});
        _chargers.Add("CHGR-04", new Charger{Id = 1, OcppChargerId = "CHGR-04", Password = "Password123", IsDeleted = false});
        _chargers.Add("CHGR-05", new Charger{Id = 1, OcppChargerId = "CHGR-05", Password = "Password123", IsDeleted = false});
        _chargers.Add("CHGR-06", new Charger{Id = 1, OcppChargerId = "CHGR-06", Password = "Password123", IsDeleted = false});
    }

    public Task AddOrUpdateChargers(AddOrUpdateChargersDto addOrUpdateChargersDto)
    {
        foreach (var dto in addOrUpdateChargersDto.Chargers)
        {
            if (!_chargers.TryGetValue(dto.OcppChargerId, out var charger))
            {
                charger = new Charger
                {
                    OcppChargerId = dto.OcppChargerId,
                    Password = dto.BasicAuthPassword,
                    DateTimeCreated = DateTime.UtcNow,
                    IsDeleted = false
                };
                _chargers[dto.OcppChargerId] = charger;
            }
            else
            {
                if (dto.BasicAuthPassword != null) charger.Password = dto.BasicAuthPassword;
            }
        }

        return Task.CompletedTask;
    }
    
    public Task<IEnumerable<Charger>> GetAllChargers()
    {
        var activeChargers = _chargers.Values
            .Where(c => !c.IsDeleted);

        return Task.FromResult(activeChargers);
    }


    public Task<ChargerDto> GetChargerByOcppChargerId(string ocppChargerId)
    {
        if (_chargers.TryGetValue(ocppChargerId, out var charger) && !charger.IsDeleted)
        {
            return Task.FromResult(_mapper.Map<ChargerDto>(charger));
        }

        throw new Exception("Charger not found");
    }
    
    public Charger GetChargerByOcppChargerIdEntity(string ocppChargerId)
    {
        if (_chargers.TryGetValue(ocppChargerId, out var charger) && !charger.IsDeleted)
        {
            return charger;
        }

        throw new Exception("Charger not found");
    }

    public Task UpdateCharger(ChargerDto dto)
    {
        if (!_chargers.TryGetValue(dto.OcppChargerId, out var charger) || charger.IsDeleted)
            throw new Exception("Charger not found");

        if (dto.Password != null) charger.Password = dto.Password;

        return Task.CompletedTask;
    }
    
    public Task UpdateChargerEntity(Charger updatedCharger)
    {
        if (!_chargers.TryGetValue(updatedCharger.OcppChargerId, out var charger) || charger.IsDeleted)
            throw new Exception("Charger not found");

        charger.Password = updatedCharger.Password;
        charger.Vendor = updatedCharger.Vendor;
        charger.Model = updatedCharger.Model;
        charger.FirmwareVersion = updatedCharger.FirmwareVersion;
        charger.ChargePointSerialNumber = updatedCharger.ChargePointSerialNumber;
        charger.Protocol = updatedCharger.Protocol;

        return Task.CompletedTask;
    }


    public Task<bool> CheckChargerCredentials(string ocppChargerId, string password)
    {
        return Task.FromResult(_chargers.TryGetValue(ocppChargerId, out var charger)
                               && !charger.IsDeleted
                               && charger.Password == password);
    }

    public Task DeleteChargers(DeleteChargersDto dto)
    {
        foreach (var chargerId in dto.ChargerIds)
        {
            if (_chargers.TryGetValue(chargerId, out var charger) && !charger.IsDeleted)
            {
                charger.IsDeleted = true;
            }
        }

        return Task.CompletedTask;
    }
}
