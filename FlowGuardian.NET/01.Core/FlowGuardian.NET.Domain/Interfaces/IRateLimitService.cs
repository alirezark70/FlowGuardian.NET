using FlowGuardian.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Interfaces
{
    public interface IRateLimitService
    {
        Task<RateLimitResult> CheckRateLimitAsync(string identifier,string? endpoint=null);

        Task<bool> IsRateLimitedAsync(string identifier);

        Task ResetRateLimitAsync(string identifier);
    }
}
