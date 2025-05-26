using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BootNotificationRequest
    {
        [Newtonsoft.Json.JsonProperty("chargePointVendor", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [DataMember(Name = "chargePointVendor")]
        public string ChargePointVendor { get; set; }

        [Newtonsoft.Json.JsonProperty("chargePointModel", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [DataMember(Name = "chargePointModel")]
        public string ChargePointModel { get; set; }

        [Newtonsoft.Json.JsonProperty("chargePointSerialNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25)]
        [DataMember(Name = "chargePointSerialNumber")]
        public string ChargePointSerialNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("chargeBoxSerialNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25)]
        [DataMember(Name = "chargeBoxSerialNumber")]
        public string ChargeBoxSerialNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("firmwareVersion", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [DataMember(Name = "firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("iccid", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [DataMember(Name = "iccid")]
        public string Iccid { get; set; }

        [Newtonsoft.Json.JsonProperty("imsi", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [DataMember(Name = "imsi")]
        public string Imsi { get; set; }

        [Newtonsoft.Json.JsonProperty("meterType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25)]
        [DataMember(Name = "meterType")]
        public string MeterType { get; set; }

        [Newtonsoft.Json.JsonProperty("meterSerialNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25)]
        [DataMember(Name = "meterSerialNumber")]
        public string MeterSerialNumber { get; set; }
    }
}