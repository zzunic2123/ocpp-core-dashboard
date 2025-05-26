using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;

public class UpdateChargerDto : Partner
{
    [Newtonsoft.Json.JsonProperty("ocppChargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "ocppChargerId")]
    public string OcppChargerId { get; set; }
    
    [Newtonsoft.Json.JsonProperty("ocppVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "ocppVersion")]
    public string? OcppVersion { get; set; }
    
    [Newtonsoft.Json.JsonProperty("model", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "model")]
    public string? Model { get; set; }
    
    [Newtonsoft.Json.JsonProperty("vendor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "vendor")]
    public string? Vendor { get; set; }
    
    [Newtonsoft.Json.JsonProperty("serialNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "firmwareVersion")]
    public string? FirmwareVersion { get; set; }
    
    [Newtonsoft.Json.JsonProperty("firmwareVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "basicAuthPassword")]
    public string? BasicAuthPassword { get; set; }
    
    [Newtonsoft.Json.JsonProperty("basicAuthUsername", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "maxPower")]
    public float? MaxPower { get; set; }
}