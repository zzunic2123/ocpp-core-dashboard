using AutoMapper;
using CPMS.OcppProxy.Data.Entities;
using CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;

namespace CPMS.OcppProxy.Profiles;

public class ChargerProfile : Profile
{
    public ChargerProfile()
    {
        CreateMap<ChargerDto, Charger>();
        CreateMap<Charger, ChargerDto>();
    }
    
}