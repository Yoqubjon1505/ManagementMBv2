using ManagementMB.Enums;

namespace ManagementMB.DTOs
{
    public class ExpenseDto
    {
        public double Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
