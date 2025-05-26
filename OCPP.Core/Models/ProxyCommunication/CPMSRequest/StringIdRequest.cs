using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class StringIdRequest
{
    [Newtonsoft.Json.JsonProperty("id")]
    [DataMember (Name = "id")]
    public string Id { get; set; }
}