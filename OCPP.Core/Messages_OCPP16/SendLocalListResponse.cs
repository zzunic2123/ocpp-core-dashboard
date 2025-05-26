using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SendLocalLIstResponse
    {
        [Newtonsoft.Json.JsonProperty("updateStatus", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [DataMember (Name = "updateStatus")]
        public UpdateStatus UpdateStatus { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum UpdateStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Accepted")]
        Accepted = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"Failed")]
        Failed = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"NotSupported")]
        NotSupported = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"VersionMismatch")]
        VersionMismatch = 3,
    }

}