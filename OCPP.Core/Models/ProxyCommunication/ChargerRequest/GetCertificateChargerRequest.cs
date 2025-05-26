using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;

public class GetCertificateChargerRequest : ProxyMessage
{
    [Newtonsoft.Json.JsonProperty("hashAlgorithm", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [DataMember(Name = "hashAlgorithm")]
    public string HashAlgorithm { get; set; }

    [Newtonsoft.Json.JsonProperty("issuerNameHash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [DataMember(Name = "issuerNameHash")]
    public string IssuerNameHash { get; set; }

    [Newtonsoft.Json.JsonProperty("issuerKeyHash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [DataMember(Name = "issuerKeyHash")]
    public string IssuerKeyHash { get; set; }

    [Newtonsoft.Json.JsonProperty("serialNumber", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [DataMember(Name = "serialNumber")]
    public string SerialNumber { get; set; }

    [Newtonsoft.Json.JsonProperty("responderURL", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [DataMember(Name = "responderURL")]
    public string ResponderURL { get; set; }
}