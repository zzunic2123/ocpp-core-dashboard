namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FirmwareStatusNotificationRequest
    {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [System.Runtime.Serialization.DataMember(Name = "status")]
        public FirmwareStatus Status { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum FirmwareStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Downloaded")]
        Downloaded = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"DownloadFailed")]
        DownloadFailed = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"Downloading")]
        Downloading = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"Idle")]
        Idle = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"InstallationFailed")]
        InstallationFailed = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"Installing")]
        Installing = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"Installed")]
        Installed = 6

    }

}