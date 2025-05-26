using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSResponse;

public class GetChargingProfilesCpmsResponse : ProxyMessage
{
    [DataMember(Name = "status")]
    public string Status { get; set; }
}