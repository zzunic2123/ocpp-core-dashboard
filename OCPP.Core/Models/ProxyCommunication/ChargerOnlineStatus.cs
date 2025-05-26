using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication;

public class ChargerOnlineStatus
{
    [DataMember(Name = "chargerId")]
    public string ChargerId { get; set; }
    [DataMember(Name = "onlineStatus")]
    public bool OnlineStatus { get; set; }
}