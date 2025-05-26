using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class DeleteChargersDto
{
    [Newtonsoft.Json.JsonProperty("chargerIds", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerIds")]
    public IList<string> ChargerIds { get; set; }
}