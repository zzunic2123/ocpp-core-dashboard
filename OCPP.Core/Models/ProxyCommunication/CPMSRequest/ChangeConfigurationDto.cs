namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class ChangeConfigurationDto
{
    public string? ChargerId { get; set; }
    public ICollection<KeyValue> Preset { get; set; }
}
