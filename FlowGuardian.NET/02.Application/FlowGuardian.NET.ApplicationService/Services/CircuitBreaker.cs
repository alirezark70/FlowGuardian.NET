using FlowGuardian.NET.Domain.Configuration;
using FlowGuardian.NET.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.ApplicationService.Services
{
    public class CircuitBreaker
    {
        private readonly CircuitBreakerOptions _options;
        private int _failureCount;
        private DateTime _lastFailureTime;
        private CircuitState _state=CircuitState.Closed;
        public CircuitState State => _state;
        private readonly object _lock = new object();

        public CircuitBreaker(CircuitBreakerOptions options)
        {
            _options = options;
        }

        public async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
        {
            if (_state == CircuitState.Open)
            {
                if (DateTime.UtcNow - _lastFailureTime > _options.BreakDuration)
                {
                    _state = CircuitState.HalfOpen;
                }
                else
                {
                    throw new Exception("Circuit breaker is open");
                }
            }

            try
            {
                var result = await action();
                if (_state == CircuitState.HalfOpen)
                {
                    _state = CircuitState.Closed;
                    _failureCount = 0;
                }
                return result;
            }
            catch
            {
                lock (_lock)
                {
                    _failureCount++;
                }

                _lastFailureTime = DateTime.UtcNow;

                if (_failureCount >= _options.FailureThreshold)
                {
                    _state = CircuitState.Open;
                }
                throw;
            }
        }
        public void Reset()
        {
            _state = CircuitState.Closed;
            _failureCount = 0;
        }
    }
}
