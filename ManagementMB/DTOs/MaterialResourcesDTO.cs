namespace ManagementMB.DTOs
{
    public class MaterialResourcesDTO
    {
        public string Name { get; set; }
        public double Transport { get; set; }
        public double Equipment { get; set; }
        public double Building { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
