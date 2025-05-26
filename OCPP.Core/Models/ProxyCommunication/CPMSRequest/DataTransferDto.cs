using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class DataTransferDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }

    [Newtonsoft.Json.JsonProperty("messageId", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [System.ComponentModel.DataAnnotations.StringLength(50)]
    [DataMember(Name = "messageId")]
    public string? MessageId { get; set; }

    [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember(Name = "data")]
    public object? Data { get; set; }

    [Newtonsoft.Json.JsonProperty("vendorId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(255)]
    [DataMember(Name = "vendorId")]
    public string VendorId { get; set; }
}

