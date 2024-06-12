using ManagementMB.Enums;

namespace ManagementMB.DTOs
{
    public class LiabilitiiesDTO
    {
        public LiabilitiiesCategory Category { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
