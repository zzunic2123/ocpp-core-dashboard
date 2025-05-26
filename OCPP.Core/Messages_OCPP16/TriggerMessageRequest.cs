using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TriggerMessageRequest
    {

        [Newtonsoft.Json.JsonProperty("requestedMessage", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [DataMember (Name = "requestedMessage")]
        public MessageTrigger RequestedMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("connectorId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "connectorId")]
        public int ConnectorId { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum MessageTrigger
    {
        [System.Runtime.Serialization.EnumMember(Value = @"BootNotification")]
        BootNotification = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"DiagnosticsStatusNotification")]
        DiagnosticsStatusNotification = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"FirmwareStatusNotification")]
        FirmwareStatusNotification = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"Heartbeat")]
        Heartbeat = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"MeterValues")]
        MeterValues = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"StatusNotification")]
        StatusNotification = 4,
    }


}