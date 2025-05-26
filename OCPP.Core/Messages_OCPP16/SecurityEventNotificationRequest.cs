using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16;

public class SecurityEventNotificationRequest
{
    [DataMember (Name = "type")]
    public string Type { get; set; }
    
    [DataMember (Name = "timestamp")]
    public DateTime Timestamp { get; set; }
    
    [DataMember (Name = "techInfo")]
    public string? TechInfo { get; set; }
}