using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication;

public class ProxyMessage
{
    [DataMember(Name = "chargerId")]
    public string ChargerId { get; set; }
    
    [DataMember(Name = "protocol")]
    public string Protocol { get; set; }
}
