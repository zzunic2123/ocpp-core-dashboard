using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class PresetDto
{
    public int Id { get; set; }
    public string? Vendor { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; }
    public ICollection<KeyValue> Preset { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public partial class KeyValue
{
    [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(50)]
    [DataMember(Name = "key")]
    public string Key { get; set; }

    [Newtonsoft.Json.JsonProperty("readonly", Required = Newtonsoft.Json.Required.Always)]
    [DataMember(Name = "readonly")]
    public bool Readonly { get; set; }

    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [System.ComponentModel.DataAnnotations.StringLength(500)]
    [DataMember(Name = "value")]
    public string Value { get; set; }

}
