using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Entities
{
    public class HealthStatus
    {
        public bool IsHealthy { get; set; }
        public string Status { get; set; } = "Unknown";
        public DateTime CheckedAt { get; set; } = DateTime.UtcNow;
        public Dictionary<string, object>? Details { get; set; }
    }
}
