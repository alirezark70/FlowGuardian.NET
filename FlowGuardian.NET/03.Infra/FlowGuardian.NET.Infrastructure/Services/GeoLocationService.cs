using FlowGuardian.NET.Domain.Configuration;
using FlowGuardian.NET.Domain.Entities;
using FlowGuardian.NET.Domain.Interfaces;
using FlowGuardian.NET.Domain.ValueObjects;
using FlowGuardian.NET.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Infrastructure.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        private readonly IRedisService redisService;
        private readonly GeoLocationOptions _options;
        private readonly HttpClient _httpClient;


        public GeoLocationService(IRedisService redisService, GeoLocationOptions options, HttpClient httpClient)
        {
            this.redisService = redisService;
            _options = options;
            _httpClient = httpClient;
        }

        public Task<GeoLocation?> GetLocationAsync(IpAddress ipAddress)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsCountryBlockedAsync(string country)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsRegionAllowedAsync(string? region)
        {
            throw new NotImplementedException();
        }
    }
}
