using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class GetDiagnosticDto
{
    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }

    [DataMember (Name = "id")]
    public string Location { get; set; }
    
    [DataMember (Name = "startTime")]
    public DateTime? StartTime { get; set; }
    
    [DataMember (Name = "stopTime")]
    public DateTime? StopTime { get; set; }
}