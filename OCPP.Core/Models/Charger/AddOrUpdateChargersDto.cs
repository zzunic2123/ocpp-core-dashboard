using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;

public class AddOrUpdateChargersDto
{
    [Newtonsoft.Json.JsonProperty("chargers", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargers")]
    public IList<UpdateChargerDto> Chargers { get; set; }
}