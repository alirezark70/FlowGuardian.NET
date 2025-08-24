using FlowGuardian.NET.Domain.Entities;
using FlowGuardian.NET.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Interfaces
{
    public interface IGeoLocationService
    {
        Task<GeoLocation?> GetLocationAsync(IpAddress ipAddress);
        Task<bool> IsCountryBlockedAsync(string country);
        Task<bool> IsRegionAllowedAsync(string? region);
    }
}
