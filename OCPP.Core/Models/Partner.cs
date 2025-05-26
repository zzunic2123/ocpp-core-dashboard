using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels;

public class Partner
{
    [Newtonsoft.Json.JsonProperty("partnerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "partnerId")]
    public string PartnerId { get; set; }
}