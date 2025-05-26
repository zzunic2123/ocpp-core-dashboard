namespace CPMS.OcppProxy.Shared.Models.ProxyModels.Charger;

public class ChargerDto
{
    public string OcppChargerId { get; set; }
    public string? OcppVersion { get; set; }
    public string? Model { get; set; }
    public string? Vendor { get; set; }
    public string? FirmwareVersion { get; set; }
    public bool? OnlineStatus { get; set; }
    public string? Password { get; set; }
    public float? MaxPower { get; set; }
    public string? OnboardingStatus { get; set; }
    public int TenantId { get; set; }
    public int? PresetId { get; set; }
    
}