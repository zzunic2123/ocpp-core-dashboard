using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class GetChargingProfilesDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember(Name = "chargerId")]
    public string ChargerId { get; set; }

    [Newtonsoft.Json.JsonProperty("evseId", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember(Name = "evseId")]
    public int? EvseId { get; set; }

    [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember(Name = "requestId")]
    public int RequestId { get; set; }

    [Newtonsoft.Json.JsonProperty("chargingProfile", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    [DataMember(Name = "chargingProfile")]
    public ChargingProfileCriterionType ChargingProfile { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public partial class ChargingProfileCriterionType
{
    [Newtonsoft.Json.JsonProperty("customData", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember(Name = "customData")]
    public CustomDataType CustomData { get; set; }

    [Newtonsoft.Json.JsonProperty("chargingProfilePurpose", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember(Name = "chargingProfilePurpose")]
    public ChargingProfilePurposeEnumType ChargingProfilePurpose { get; set; }

    [Newtonsoft.Json.JsonProperty("stackLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember(Name = "stackLevel")]
    public int StackLevel { get; set; }

    [Newtonsoft.Json.JsonProperty("chargingProfileId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember(Name = "chargingProfileId")]
    public ICollection<int> ChargingProfileId { get; set; }

    [Newtonsoft.Json.JsonProperty("chargingLimitSource", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [System.ComponentModel.DataAnnotations.MaxLength(4)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember(Name = "chargingLimitSource")]
    public ICollection<ChargingLimitSourceEnumType> ChargingLimitSource { get; set; }

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum ChargingProfilePurposeEnumType
{
    [System.Runtime.Serialization.EnumMember(Value = @"ChargingStationExternalConstraints")]
    ChargingStationExternalConstraints = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"ChargingStationMaxProfile")]
    ChargingStationMaxProfile = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"TxDefaultProfile")]
    TxDefaultProfile = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"TxProfile")]
    TxProfile = 3,
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum ChargingLimitSourceEnumType
{
    [System.Runtime.Serialization.EnumMember(Value = @"EMS")]
    EMS = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"Other")]
    Other = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"SO")]
    SO = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"CSO")]
    CSO = 3,

}