namespace ManagementMB.Models
{
    public class Purchase:BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double CostPrice { get; set; }
        public double TotalCostPrice { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

       
    }
}
