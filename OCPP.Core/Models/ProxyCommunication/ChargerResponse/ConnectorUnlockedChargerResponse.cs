using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;

public class ConnectorUnlockedChargerResponse
{
    [DataMember(Name = "chargerId")]
    public string ChargerId { get; set; }
    
    [DataMember(Name = "evseId")]
    public int EvseId { get; set; }
    
    [DataMember(Name = "connectorId")]
    public int ConnectorId { get; set; }
    
    [DataMember(Name = "status")]
    public string Status { get; set; }
}