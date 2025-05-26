using System.Runtime.Serialization;
using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ProxyResponse;

public class StartTransactionResponse
{
    [Newtonsoft.Json.JsonProperty("idTagInfo", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    [DataMember (Name = "idTagInfo")]
    public IdTagInfo IdTagInfo { get; set; } = new IdTagInfo();

    [Newtonsoft.Json.JsonProperty("transactionId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "transactionId")]
    public int TransactionId { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public partial class IdTagInfo
{
    [Newtonsoft.Json.JsonProperty("expiryDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember(Name = "expiryDate")]
    public DateTimeOffset? ExpiryDate { get; set; }

    [Newtonsoft.Json.JsonProperty("parentIdTag", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(20)]
    [DataMember(Name = "parentIdTag")]
    public string? ParentIdTag { get; set; }

    [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember(Name = "status")]
    public AuthorizationStatus Status { get; set; }
}