using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Configuration
{
    public class GeoLocationOptions
    {
        public List<string> BlockedCountries { get; set; } = new();
        public List<string> AllowedRegions { get; set; } = new();
        public string? MaxMindLicenseKey { get; set; }
    }
}
