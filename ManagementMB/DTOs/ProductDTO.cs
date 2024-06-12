using ManagementMB.Enums;

namespace ManagementMB.DTOs
{
    public class ProductDTO
    {
        public int Quantity { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double CostPrice { get; set; }
      
    }
}
