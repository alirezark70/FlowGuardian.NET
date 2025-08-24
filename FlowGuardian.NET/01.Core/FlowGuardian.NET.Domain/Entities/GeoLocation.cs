namespace FlowGuardian.NET.Domain.Entities
{
    public class GeoLocation
    {
        public string Country { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Region { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? TimeZone { get; set; }
        public string? Isp { get; set; }
    }



}
