using ManagementMB.Models;

namespace ManagementMB.DTOs
{
    public class SaleDTO
    {
        public Product Product { get; set; }
        public double TotalPrice { get; set; }
        public int QuantitySold { get; set; }
    }
}
