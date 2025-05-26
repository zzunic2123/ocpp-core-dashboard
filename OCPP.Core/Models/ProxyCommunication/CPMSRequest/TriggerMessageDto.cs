using System.Runtime.Serialization;

public class TriggerMessageDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember(Name = "chargerId")]
    public string ChargerId { get; set; }

    [Newtonsoft.Json.JsonProperty("evseId", Required = Newtonsoft.Json.Required.AllowNull)]
    [DataMember(Name = "evseId")]
    public int? EvseId { get; set; }

    [Newtonsoft.Json.JsonProperty("connectorId", Required = Newtonsoft.Json.Required.AllowNull)]
    [DataMember(Name = "connectorId")]
    public int? ConnectorId { get; set; }

    [Newtonsoft.Json.JsonProperty("requestedMessage", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    [DataMember(Name = "requestedMessage")]
    public MessageTriggerEnumType RequestedMessage { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum MessageTriggerEnumType
{
    [System.Runtime.Serialization.EnumMember(Value = @"BootNotification")]
    BootNotification = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"LogStatusNotification")]
    LogStatusNotification = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"FirmwareStatusNotification")]
    FirmwareStatusNotification = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"Heartbeat")]
    Heartbeat = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"MeterValues")]
    MeterValues = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"SignChargingStationCertificate")]
    SignChargingStationCertificate = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"SignV2GCertificate")]
    SignV2GCertificate = 6,

    [System.Runtime.Serialization.EnumMember(Value = @"StatusNotification")]
    StatusNotification = 7,

    [System.Runtime.Serialization.EnumMember(Value = @"TransactionEvent")]
    TransactionEvent = 8,

}
