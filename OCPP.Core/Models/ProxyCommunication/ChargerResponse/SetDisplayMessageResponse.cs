using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;

public class SetDisplayMessageResponse : ProxyMessage
{
    [DataMember(Name = "status")]
    public string Status { get; set; }
}