using ManagementMB.Enums;

namespace ManagementMB.Models
{
    public class Product : BaseEntity
    {
        public double Quantity { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double CostPrice { get; set; }
        public double TotalPrice { get; set; }
        public double TotalCostPrice { get; set; }
        public bool Availability { get; set; }
    }
}
