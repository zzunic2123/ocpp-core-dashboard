namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;

public class MeterValueChargerRequest : ProxyMessage
{
    public int? TransactionId { get; set; }
    public string TransactionStringId { get; set; }
    public double? CurrentPower { get; set; }
    public double? EnergyConsumed { get; set; }
    public DateTimeOffset? MeterTime { get; set; }
    public double? StateOfCharge { get; set; }
}