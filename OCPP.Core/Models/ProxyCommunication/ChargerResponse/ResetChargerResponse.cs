using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;

public class ResetChargerResponse : ProxyMessage
{
    [DataMember(Name = "status")]
    public string Status { get; set; }

    [DataMember(Name = "reasonCode")]
    public string Reason { get; set; }
}