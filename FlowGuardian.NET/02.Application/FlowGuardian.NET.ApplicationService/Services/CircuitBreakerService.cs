using FlowGuardian.NET.Domain.Configuration;
using FlowGuardian.NET.Domain.Enums;
using FlowGuardian.NET.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.ApplicationService.Services
{
    public class CircuitBreakerService : ICircuitBreakerService
    {
        private readonly Dictionary<string, CircuitBreaker> _breakers = new();
        private readonly CircuitBreakerOptions _options;

        public CircuitBreakerService(CircuitBreakerOptions options)
        {
            _options = options;
        }

        public async Task<T> ExecuteAsync<T>(string key, Func<Task<T>> action)
        {
            var breaker = GetOrCreateBreaker(key);
            return await breaker.ExecuteAsync(action);
        }

        public CircuitState GetState(string key)
        {
            return GetOrCreateBreaker(key).State;
        }

        public void Reset(string key)
        {
            if (_breakers.TryGetValue(key, out var breaker))
            {
                breaker.Reset();
            }
        }

        private CircuitBreaker GetOrCreateBreaker(string key)
        {
            if (!_breakers.TryGetValue(key, out var breaker))
            {
                breaker = new CircuitBreaker(_options);
                _breakers[key] = breaker;
            }
            return breaker;
        }
    }
}
