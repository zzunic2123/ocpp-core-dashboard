using System.Runtime.Serialization;
using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSResponse;

public class GetConfigurationCpmsResponse : ProxyMessage
{
    [DataMember (Name = "isConfigurationLive")]
    public bool IsConfigurationLive { get; set; }
    
    [DataMember (Name = "configuration")]
    public ICollection<KeyValue> Configuration { get; set; }
}