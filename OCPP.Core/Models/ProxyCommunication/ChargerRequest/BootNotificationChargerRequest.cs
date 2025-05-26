using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;

public class BootNotificationChargerRequest : ProxyMessage
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

        [Newtonsoft.Json.JsonProperty("chargeBoxSerialNumber", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(25)]
        [DataMember(Name = "chargeBoxSerialNumber")]
        public string ChargeBoxSerialNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("firmwareVersion", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        [DataMember(Name = "firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("iccid", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [DataMember(Name = "iccid")]
        public string Iccid { get; set; }

        [Newtonsoft.Json.JsonProperty("imsi", Required = Newtonsoft.Json.Required.AllowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(20)]
        [DataMember(Name = "imsi")]
        public string Imsi { get; set; }

        [Newtonsoft.Json.JsonProperty("reason", Required = Newtonsoft.Json.Required.AllowNull)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [DataMember(Name = "reason")]
        public string Reason { get; set; }
}


public class ProxyMessage
{
    [DataMember(Name = "chargerId")]
    public string ChargerId { get; set; }
    
    [DataMember(Name = "protocol")]
    public string Protocol { get; set; }
}
