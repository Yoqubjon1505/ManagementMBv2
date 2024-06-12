using ManagementMB.Enums;

namespace ManagementMB.Models
{
    public class Sale : BaseEntity
    {
        public string Name { get; set; }
        public double QuantitySold { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
       
    }
}    

