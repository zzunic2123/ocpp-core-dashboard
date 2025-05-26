using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DiagnosticsStatusNotificationRequest
    {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [DataMember (Name = "status")]
        public DiagnosticsStatus Status { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum DiagnosticsStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Idle")]
        Idle = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"Uploaded")]
        Uploaded = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"UploadFailed")]
        UploadFailed = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"Uploading")]
        Uploading = 3,

    }

}
