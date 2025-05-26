using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class ChangeAvailabilityDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }

    [Newtonsoft.Json.JsonProperty("evseId", Required = Newtonsoft.Json.Required.AllowNull)]
    [DataMember(Name = "evseId")]
    public int? EvseId { get; set; }

    [Newtonsoft.Json.JsonProperty("connectorId", Required = Newtonsoft.Json.Required.AllowNull)]
    [DataMember (Name = "connectorId")]
    public int? ConnectorId { get; set; }

    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember (Name = "type")]
    public AvailabilityType Type { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum AvailabilityType
{
    [System.Runtime.Serialization.EnumMember(Value = @"Inoperative")]
    Inoperative = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"Operative")]
    Operative = 1,
}
