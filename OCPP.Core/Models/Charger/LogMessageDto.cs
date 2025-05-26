namespace CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;

public class LogMessageDto
{
    public int Id { get; set; }

    public string ChargerId { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    // Server, Charger
    public string? Sender { get; set; }

    public string MessageTypeId { get; set; }

    // request, response, error
    public string? MessageType { get; set; }
    
    public string UniqueId { get; set; }

    // Id for connecting request and response
    public string? MessageId { get; set; }

    public string Action { get; set; }
    
    public string JsonPayload { get; set; }
    
    public string? ErrorCode { get; set; }
    
    public string? ErrorDescription { get; set; }
}