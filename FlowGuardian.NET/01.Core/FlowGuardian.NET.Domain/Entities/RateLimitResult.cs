using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Entities
{
    public class RateLimitResult
    {
        public bool IsAllowed { get; set; }
        public int RemainingRequests { get; set; }
        public DateTime? RetryAfter { get; set; }
        public string? Message { get; set; }
    }
}
