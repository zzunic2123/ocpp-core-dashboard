namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;

public class SecurityEventNotificationChargerRequest : ProxyMessage
{
    public string Type { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public string? TechInfo { get; set; }
}