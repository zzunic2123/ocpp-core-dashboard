using System.CodeDom.Compiler;
using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

[GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class ResetDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }
    
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember (Name = "type")]
    public ResetType Type { get; set; }
    
    [Newtonsoft.Json.JsonProperty("evseId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "evseId")]
    public int? EvseId { get; set; }
}

[GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum ResetType
{
    [System.Runtime.Serialization.EnumMember(Value = @"Hard")]
    Hard = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"Soft")]
    Soft = 1,

}