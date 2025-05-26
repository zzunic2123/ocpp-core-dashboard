using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;
using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;

public class AuthorizeChargerRequest : ProxyMessage
{
    public string IdTag { get; set; }
    public string Type { get; set; }
    public ICollection<OCSPRequestDataType> Iso15118CertificateHashData { get; set; }
}

public partial class OCSPRequestDataType
{
    [Newtonsoft.Json.JsonProperty("customData", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember(Name = "customData")]
    public CustomDataType CustomData { get; set; }

    [Newtonsoft.Json.JsonProperty("hashAlgorithm", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember(Name = "hashAlgorithm")]
    public HashAlgorithmEnumType HashAlgorithm { get; set; }

    [Newtonsoft.Json.JsonProperty("issuerNameHash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(128)]
    [DataMember(Name = "issuerNameHash")]
    public string IssuerNameHash { get; set; }

    [Newtonsoft.Json.JsonProperty("issuerKeyHash", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(128)]
    [DataMember(Name = "issuerKeyHash")]
    public string IssuerKeyHash { get; set; }

    [Newtonsoft.Json.JsonProperty("serialNumber", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(40)]
    [DataMember(Name = "serialNumber")]
    public string SerialNumber { get; set; }

    [Newtonsoft.Json.JsonProperty("responderURL", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(512)]
    [DataMember(Name = "responderURL")]
    public string ResponderURL { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum HashAlgorithmEnumType
{
    [System.Runtime.Serialization.EnumMember(Value = @"SHA256")]
    SHA256 = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"SHA384")]
    SHA384 = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"SHA512")]
    SHA512 = 2,

}