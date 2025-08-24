using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Enums
{
    public enum RateLimitScope
    {
        Global,
        PerIp,
        PerUser,
        PerApiKey,
        PerEndpoint
    }
}
