using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public class RemoteStopTransactionDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }

    [Newtonsoft.Json.JsonProperty("transactionId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "transactionId")]
    public int TransactionId { get; set; }
    
    [Newtonsoft.Json.JsonProperty("transactionStringId", Required = Newtonsoft.Json.Required.AllowNull)]
    [DataMember (Name = "transactionStringId")]
    public string TransactionStringId { get; set; }
}