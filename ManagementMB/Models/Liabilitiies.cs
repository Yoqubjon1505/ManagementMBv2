using ManagementMB.Enums;

namespace ManagementMB.Models
{
    public class Liabilitiies:BaseEntity
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public LiabilitiiesCategory Category { get; set; }
    }
}
