using FlowGuardian.NET.Domain.Enums;

namespace FlowGuardian.NET.Domain.Entities
{
    public class RateLimitRule
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public int MaxRequests { get; set; }
        public TimeSpan TimeWindow { get; set; }
        public RateLimitScope Scope { get; set; }
        public string? PathPattern { get; set; }
        public bool IsEnabled { get; set; } = true;
    }



}
