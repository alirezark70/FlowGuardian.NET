using FlowGuardian.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Interfaces
{
    public interface IHealthCheckService
    {
        Task<HealthStatus> CheckHealthAsync();
        Task<Dictionary<string, ComponentHealth>> CheckComponentsHealthAsync();
    }
}
