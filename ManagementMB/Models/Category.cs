namespace ManagementMB.Models
{
    public class Category:BaseEntity
    {
        public IQueryable<Product> ProductCategory { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
