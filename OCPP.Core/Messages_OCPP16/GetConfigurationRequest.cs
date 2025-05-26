using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16

{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GetConfigurationRequest
    {
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "key")]
        public ICollection<string> Key { get; set; }
    }
}
