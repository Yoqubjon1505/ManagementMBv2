namespace ManagementMB.Models
{
    public class MaterialResources: BaseEntity
    {
        public string Name { get; set; }
        public double Transport { get; set; }
        public double Equipment { get; set; }
        public double Building { get; set; }
       
    }
}
