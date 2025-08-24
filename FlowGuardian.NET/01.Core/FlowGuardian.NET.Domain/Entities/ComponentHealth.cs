namespace FlowGuardian.NET.Domain.Entities
{
    public class ComponentHealth
    {
        public string Name { get; set; } = string.Empty;
        public bool IsHealthy { get; set; }
        public string? Message { get; set; }
        public TimeSpan ResponseTime { get; set; }
    }
}
