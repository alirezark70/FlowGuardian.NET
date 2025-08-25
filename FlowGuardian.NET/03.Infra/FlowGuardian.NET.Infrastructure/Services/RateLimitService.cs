using FlowGuardian.NET.Domain.Configuration;
using FlowGuardian.NET.Domain.Entities;
using FlowGuardian.NET.Domain.Interfaces;
using FlowGuardian.NET.Infrastructure.Contracts;

namespace FlowGuardian.NET.Infrastructure.Services
{
    public class RateLimitService : IRateLimitService
    {
        private readonly IRedisService _cache;
        private readonly RateLimitOptions _options;
        private object _lock=new object();
        public RateLimitService(RateLimitOptions options, IRedisService cache)
        {
            _options = options;
            _cache = cache;
        }
        public async Task<RateLimitResult> CheckRateLimitAsync(string identifier, string? endpoint = null)
        {
            var key = GenerateKey(identifier, endpoint);
            var windowStart = GetWindowStart();
            var cacheKey = $"ratelimit:{key}:{windowStart}";

            var countStr = await _cache.GetAsync(cacheKey);
            var count = string.IsNullOrEmpty(countStr) ? 0 : int.Parse(countStr);

            var limit = GetLimit(endpoint);

            if (count >= limit)
            {
                return new RateLimitResult
                {
                    IsAllowed = false,
                    RemainingRequests = 0,
                    RetryAfter = windowStart.Add(_options.Window),
                    Message = "Rate limit exceeded"
                };
            }
            lock(_lock)
            {
                count++;
            }

            await _cache.SetAsync(cacheKey, count.ToString(), _options.Window);

            return new RateLimitResult
            {
                IsAllowed = true,
                RemainingRequests = limit - count
            };
        }

        public async Task<bool> IsRateLimitedAsync(string identifier)
        {
            var result = await CheckRateLimitAsync(identifier);
            return !result.IsAllowed;
        }

        public async Task ResetRateLimitAsync(string identifier)
        {
            var windowStart = GetWindowStart();
            var cacheKey = $"ratelimit:{identifier}:{windowStart}";
            await _cache.DeleteAsync(cacheKey);
        }

        string GenerateKey(string identifier,string? endpoint)
        {
            return string.IsNullOrEmpty(endpoint) ? identifier : $"{identifier}:{endpoint}";
        }


        DateTime GetWindowStart()
        {
            var now= DateTime.UtcNow;
            var windowTicks = _options.Window.Ticks;
            var startTicks = (now.Ticks / windowTicks) * windowTicks;
            return new DateTime(startTicks,DateTimeKind.Utc);
        }

        int GetLimit(string? endpoint)
        {
            if (!string.IsNullOrEmpty(endpoint) && _options.EndpointLimits.TryGetValue(endpoint, out var limits))
            {
                return limits;
            }
            return _options.DefaultLimit;
        }
    }
}