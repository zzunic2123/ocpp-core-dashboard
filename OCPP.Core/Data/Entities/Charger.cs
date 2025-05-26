using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CPMS.OcppProxy.Data.Entities;

    public class Charger
    {
        public int Id { get; set; }
        public string OcppChargerId { get; set; }
        public string? Password { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public string? Vendor { get; set; }
        public string? Model { get; set; }
        public string? ChargePointSerialNumber { get; set; }
        public string? FirmwareVersion { get; set; }
        public string? Protocol { get; set; }

    }


