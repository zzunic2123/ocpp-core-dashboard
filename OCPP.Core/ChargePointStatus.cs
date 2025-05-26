using System.Net.WebSockets;
using System.Runtime.Serialization;

namespace CPMS.OcppProxy
{
    /// <summary>
    /// Encapsulates the data of a connected chargepoint in the server
    /// </summary>
    public class ChargePointStatus
    {

        public const string Protocol_OCPP16 = "ocpp1.6";
        public const string Protocol_OCPP201 = "ocpp2.0.1";
        public ChargePointStatus(string chargePointId)
        {
            Id = chargePointId;
        }

        /// <summary>
        /// Name of chargepoint
        /// </summary>
        [DataMember (Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// OCPP protocol version
        /// </summary>
        [DataMember(Name = "protocol")]
        public string Protocol { get; set; }
        

        /// <summary>
        /// WebSocket for internal processing
        /// </summary>
        [IgnoreDataMember]
        public WebSocket WebSocket { get; set; }
        
        [IgnoreDataMember]
        public Info? Info { get; set; }
    }

    public enum ConnectorStatusEnum
    {
        [EnumMember(Value = @"")]
        Undefined = 0,

        [EnumMember(Value = @"Available")]
        Available = 1,

        [EnumMember(Value = @"Occupied")]
        Occupied = 2,

        [EnumMember(Value = @"Unavailable")]
        Unavailable = 3,

        [EnumMember(Value = @"Faulted")]
        Faulted = 4
    }

    public class Info
    {
        public string? Vendor { get; set; }
        public string? Model { get; set; }
        public string? ChargePointSerialNumber { set; get; }
        public string? ChargeBoxSerialNumber { set; get; }
        public string? FirmwareVersion { get; set; }
        public string? Iccid { get; set; }
        public string? Imsi { get; set; }
        public string? MeterType { get; set; }
        public string? MeterSerialNumber { get; set; }
    }
    
}
