using FlowGuardian.NET.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Interfaces
{
    public interface ICircuitBreakerService
    {
        Task<T> ExecuteAsync<T>(string key, Func<Task<T>> action);
        CircuitState GetState(string key);
        void Reset(string key);
    }
}
