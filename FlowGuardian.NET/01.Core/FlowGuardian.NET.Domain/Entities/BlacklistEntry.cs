using FlowGuardian.NET.Domain.Enums;

namespace FlowGuardian.NET.Domain.Entities
{
    public class BlacklistEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Value { get; set; } = string.Empty;
        public BlacklistType Type { get; set; }
        public string? Reason { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public bool IsActive { get; set; } = true;
    }



}
