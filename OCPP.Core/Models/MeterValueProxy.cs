namespace CPMS.OcppProxy.Models;

public class MeterValueProxy
{
    public double CurrentPower { get; set; }
    public double EnergyConsumed { get; set; }
    public DateTimeOffset? MeterTime { get; set; }
    public double StateOfCharge { get; set; }
}