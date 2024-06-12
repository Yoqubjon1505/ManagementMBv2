namespace ManagementMB.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }
        public DateTime DateTime { get; set; } 

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            DateTime = DateTime.Now;
        }

        public string Description { get; set; } = string.Empty;
    }
}
