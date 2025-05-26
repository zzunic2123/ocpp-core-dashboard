namespace CPMS.OcppProxy.Data.Entities;

public class ChargingSession
{
    public int Id { get; set; }
    public string OcppChargerId { get; set; }
    public int ConnectorId { get; set; }
    public DateTime TimeStart { get; set; }
    public DateTime? TimeStop { get; set; }
    public double MeterStart { get; set; }
    public double? MeterStop { get; set; }
    public string IdTag { get; set; }
    public string StopReason { get; set; }
}
