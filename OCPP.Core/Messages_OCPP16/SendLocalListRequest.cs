using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SendLocalListRequest
    {
        [Newtonsoft.Json.JsonProperty("listVersion", Required = Newtonsoft.Json.Required.Always)]
        [DataMember (Name = "listVersion")]
        public int ListVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("localAuthorizationKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [DataMember (Name = "localAuthorizationKey")]
        public ICollection<AuthorizationData> LocalAuthorizationList { get; set; } = new System.Collections.ObjectModel.Collection<AuthorizationData>();

        [Newtonsoft.Json.JsonProperty("updateType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [DataMember (Name = "updateType")]
        public UpdateType UpdateType { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]

    public partial class AuthorizationData
    {
        [Newtonsoft.Json.JsonProperty("idTag", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [DataMember (Name = "idTag")]
        public string IdTag { get; set; }

        [Newtonsoft.Json.JsonProperty("idTagInfo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "idTagInfo")]
        public IdTagInfo IdTagInfo { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum UpdateType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Differential")]
        Differential = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"Full")]
        Full = 1,
    }
}