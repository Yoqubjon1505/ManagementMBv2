using ManagementMB.Enums;

namespace ManagementMB.DTOs
{
    public class SaleProductDTO
    {
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
         public  Guid ProductId { get; set; }
    }
}
