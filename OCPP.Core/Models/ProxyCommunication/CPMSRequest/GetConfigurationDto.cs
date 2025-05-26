using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class GetConfigurationDto
{
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }
}