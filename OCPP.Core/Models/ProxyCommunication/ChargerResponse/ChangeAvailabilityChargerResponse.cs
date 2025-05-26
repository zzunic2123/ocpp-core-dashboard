using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;

public class ChangeAvailabilityChargerResponse : ProxyMessage
{
    [DataMember (Name = "connectorId")]
    public int ConnectorId { get; set; }
    
    [DataMember (Name = "status")]
    public string Status { get; set; }
}