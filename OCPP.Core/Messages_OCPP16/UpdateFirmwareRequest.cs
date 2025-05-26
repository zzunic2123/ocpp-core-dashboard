using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class UpdateFirmwareRequest
    {
        [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [Url]
        [DataMember (Name = "location")]
        public string Location { get; set; }

        [Newtonsoft.Json.JsonProperty("retries", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "retries")]
        public int Retries { get; set; }

        [Newtonsoft.Json.JsonProperty("retrieveDate", Required = Newtonsoft.Json.Required.Always)]
        [Required(AllowEmptyStrings = true)]
        [DataMember (Name = "retrieveDate")]
        public DateTimeOffset RetrieveDate { get; set; }

        [Newtonsoft.Json.JsonProperty("retryInterval", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "retryInterval")]
        public int RetryInterval { get; set; }


    }


}