using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RemoteStopTransactionRequest
    {

        [Newtonsoft.Json.JsonProperty("transactionId", Required = Newtonsoft.Json.Required.Always)]
        [DataMember (Name = "transactionId")]
        public int TransactionId { get; set; }

    }

}
