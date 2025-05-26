using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class RemoteStartTransactionDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }

    [Newtonsoft.Json.JsonProperty("connectorId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "connectorId")]
    public int ConnectorId { get; set; }

    [Newtonsoft.Json.JsonProperty("idTag", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(20)]
    [DataMember (Name = "idTag")]
    public string IdTag { get; set; }
    
    [Newtonsoft.Json.JsonProperty("evseId", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "evseId")]
    public int? EvseId { get; set; }
    

    [Newtonsoft.Json.JsonProperty("idToken", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    [DataMember (Name = "idToken")]
    public IdTokenType IdToken { get; set; } = new IdTokenType();
    
    /// <summary>Id given by the server to this start request. The Charging Station might return this in the &amp;lt;&amp;lt;transactioneventrequest, TransactionEventRequest&amp;gt;&amp;gt;, letting the server know which transaction was started for this request. Use to start a transaction.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("remoteStartId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "remoteStartId")]
    public int RemoteStartId { get; set; }

   public SetChargingProfileDto? SetChargingProfileDto { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public partial class IdTokenType
{
    [Newtonsoft.Json.JsonProperty("additionalInfo", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    //[System.ComponentModel.DataAnnotations.MinLength(1)]
    [DataMember (Name = "additionalInfo")]
    public ICollection<AdditionalInfoType>? AdditionalInfo { get; set; }

    /// <summary>IdToken is case insensitive. Might hold the hidden id of an RFID tag, but can for example also contain a UUID.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("idToken", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(36)]
    [DataMember (Name = "idToken")]
    public string IdToken { get; set; }

    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember (Name = "type")]
    public IdTokenEnumType Type { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum IdTokenEnumType
{
    [System.Runtime.Serialization.EnumMember(Value = @"Central")]
    Central = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"eMAID")]
    EMAID = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"ISO14443")]
    ISO14443 = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"ISO15693")]
    ISO15693 = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"KeyCode")]
    KeyCode = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"Local")]
    Local = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"MacAddress")]
    MacAddress = 6,

    [System.Runtime.Serialization.EnumMember(Value = @"NoAuthorization")]
    NoAuthorization = 7,

}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public partial class AdditionalInfoType
{
    [Newtonsoft.Json.JsonProperty("customData", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [DataMember (Name = "customData")]
    public CustomDataType CustomData { get; set; }

    /// <summary>This field specifies the additional IdToken.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("additionalIdToken", Required = Newtonsoft.Json.Required.AllowNull)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(36)]
    [DataMember (Name = "additionalIdToken")]
    public string AdditionalIdToken { get; set; }

    /// <summary>This defines the type of the additionalIdToken. This is a custom type, so the implementation needs to be agreed upon by all involved parties.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.AllowNull)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(50)]
    [DataMember (Name = "type")]
    public string Type { get; set; }


}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public partial class CustomDataType
{
    [Newtonsoft.Json.JsonProperty("vendorId", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [System.ComponentModel.DataAnnotations.StringLength(255)]
    [DataMember (Name = "vendorId")]
    public string VendorId { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    [DataMember (Name = "additionalProperties")]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}