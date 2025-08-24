using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Entities
{
    public class RequestInfo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IpAddress { get; set; } = string.Empty;
        public string? UserAgent { get; set; }
        public string? Path { get; set; }
        public string? Method { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Dictionary<string, string> Headers { get; set; } = new();
        public string? GeoLocation { get; set; }
        public bool IsSuspicious { get; set; }
        public string? SuspiciousReason { get; set; }
    }



}
