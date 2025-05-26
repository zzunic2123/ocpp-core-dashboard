namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;

public class StatusNotificationChargerRequest : ProxyMessage
{
    public string OcppChargerId { get; set; }
    public int OcppEvseId { get; set; }
    public int OcppConnectorId { get; set; }
    public string? LastStatus { get; set; }
    public DateTime? LastStatusTime { get; set; }
}