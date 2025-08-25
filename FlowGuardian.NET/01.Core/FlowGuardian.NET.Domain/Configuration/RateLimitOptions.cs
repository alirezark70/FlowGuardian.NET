using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Configuration
{
    public class RateLimitOptions
    {
        public int DefaultLimit { get; set; } = 100;
        public TimeSpan Window { get; set; } = TimeSpan.FromMinutes(1);
        public Dictionary<string, int> EndpointLimits { get; set; } = new();
    }
}
