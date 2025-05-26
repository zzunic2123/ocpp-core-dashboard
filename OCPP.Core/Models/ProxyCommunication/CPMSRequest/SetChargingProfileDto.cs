using System.Runtime.Serialization;

namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class SetChargingProfileDto
{
    [Newtonsoft.Json.JsonProperty("connectorId")]
    [DataMember (Name = "connectorId")]
    public int? ConnectorId { get; set; }

    [Newtonsoft.Json.JsonProperty("evseId")]
    [DataMember(Name = "evseId")]
    public int? EvseId { get; set; }

    [Newtonsoft.Json.JsonProperty("chargerId", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "chargerId")]
    public string ChargerId { get; set; }
    
    [Newtonsoft.Json.JsonProperty("transactionId")]
    [DataMember (Name = "transactionId")]
    public int? TransactionId { get; set; }
    
    [Newtonsoft.Json.JsonProperty("chargingProfilePurpose")]
    [DataMember (Name = "chargingProfilePurpose")]
    public ChargingProfilePurposeTypeProxy? ChargingProfilePurpose { get; set; }
    
    [Newtonsoft.Json.JsonProperty("validFrom")]
    [DataMember (Name = "validFrom")]
    public DateTimeOffset? ValidFrom { get; set; }
        
    [Newtonsoft.Json.JsonProperty("validTo")]
    [DataMember (Name = "validTo")]
    public DateTimeOffset? ValidTo { get; set; }
    
    [Newtonsoft.Json.JsonProperty("startSchedule")]
    [DataMember (Name = "startSchedule")]
    public DateTimeOffset? StartSchedule { get; set; }
    
    [Newtonsoft.Json.JsonProperty("periods", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "periods")]
    public List<ChargingPeriod> Periods { get; set; }
    
    public override string ToString()
    {
        return $"ConnectorId: {ConnectorId}, ChargerId: {ChargerId}, TransactionId: {TransactionId}, ChargingProfilePurpose: {ChargingProfilePurpose}, ValidFrom: {ValidFrom}, ValidTo: {ValidTo}, StartSchedule: {StartSchedule}, " +
               $"PeriodsCount: {Periods.Count}" +
               $"Periods: {string.Join(", ", Periods.ToString())}";
    }
}

public class ChargingPeriod
{
    /// <summary>
    /// The period start time in seconds from the start of schedule.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("startPeriod", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "startPeriod")]
    public int StartPeriod { get; set; }

    [Newtonsoft.Json.JsonProperty("limitInAmpere", Required = Newtonsoft.Json.Required.Always)]
    [DataMember (Name = "limitInAmpere")]
    public decimal LimitInAmpere { get; set; }
    
    public override string ToString()
    {
        return $"StartPeriod: {StartPeriod}, LimitInAmpere: {LimitInAmpere}";
    }
}

    
public enum ChargingProfilePurposeTypeProxy
{
    [System.Runtime.Serialization.EnumMember(Value = @"ChargePointMaxProfile")]
    ChargePointMaxProfile = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"TxDefaultProfile")]
    TxDefaultProfile = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"TxProfile")]
    TxProfile = 2,
}