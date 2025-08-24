using FlowGuardian.NET.Domain.Entities;
using FlowGuardian.NET.Domain.Enums;
using FlowGuardian.NET.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.ApplicationService.Services
{
    public class RequestAnalyzer : IRequestAnalyzer
    {

        private readonly IRateLimitService _rateLimitService;
        private readonly IGeoLocationService _geoLocationService;
        private readonly ISuspiciousDetectionService _suspiciousDetectionService;
        private readonly ILogger<RequestAnalyzer> _logger;

        public RequestAnalyzer(
            IRateLimitService rateLimitService,
            IGeoLocationService geoLocationService,
            ISuspiciousDetectionService suspiciousDetectionService,
            ILogger<RequestAnalyzer> logger)
        {
            _rateLimitService = rateLimitService;
            _geoLocationService = geoLocationService;
            _suspiciousDetectionService = suspiciousDetectionService;
            _logger = logger;
        }

        public async Task<RequestAnalysis> AnalyzeAsync(RequestInfo request)
        {
            var result = new RequestAnalysis
            {
                RequestId = request.Id,
                Timestamp = DateTime.UtcNow
            };

            // Check Rate Limiting
            var rateLimitResult = await _rateLimitService.CheckRateLimitAsync(request.IpAddress.ToString(), request.Path);
            if (!rateLimitResult.IsAllowed)
            {
                result.IsAllowed = false;
                result.BlockReason = "Rate limit exceeded";
                result.RetryAfter = rateLimitResult.RetryAfter;
                return result;
            }

            // Check Geo Location
            var location = await _geoLocationService.GetLocationAsync(request.IpAddress);
            if (location != null)
            {
                request.GeoLocation = location.Country;
                if (await _geoLocationService.IsCountryBlockedAsync(location.Country))
                {
                    result.IsAllowed = false;
                    result.BlockReason = $"Country blocked: {location.Country}";
                    return result;
                }
            }

            // Check for Suspicious Activity
            var suspiciousResult = await _suspiciousDetectionService.AnalyzeRequestAsync(request);
            if (suspiciousResult.IsSuspicious && suspiciousResult.RecommendedAction == SuspiciousAction.Block)
            {
                result.IsAllowed = false;
                result.BlockReason = $"Suspicious activity detected: {string.Join(", ", suspiciousResult.Reasons)}";
                result.SuspicionScore = suspiciousResult.SuspicionScore;
                return result;
            }

            result.IsAllowed = true;
            result.SuspicionScore = suspiciousResult.SuspicionScore;
            result.Metadata = new Dictionary<string, object>
            {
                ["RemainingRequests"] = rateLimitResult.RemainingRequests,
                ["Country"] = location?.Country ?? "Unknown",
                ["SuspiciousReasons"] = suspiciousResult.Reasons
            };

            return result;
        }
    }
}
