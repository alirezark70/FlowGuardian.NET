using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Entities
{
    public class RequestAnalysis
    {
        public string RequestId { get; set; } = string.Empty;
        public bool IsAllowed { get; set; }
        public string? BlockReason { get; set; }
        public DateTime? RetryAfter { get; set; }
        public double SuspicionScore { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }
    }
}
