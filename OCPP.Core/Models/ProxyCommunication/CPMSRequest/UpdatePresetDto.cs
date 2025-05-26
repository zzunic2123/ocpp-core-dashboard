namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class UpdatePresetDto
{
    public int Id { get; set; }
    public ICollection<KeyValue> Preset { get; set; }
}