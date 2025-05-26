namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class SetChargerOrVendorPresetDto
{
    public string? ChargerId { get; set; }
    public string? Vendor { get; set; } 
    public int? PresetId { get; set; }
}