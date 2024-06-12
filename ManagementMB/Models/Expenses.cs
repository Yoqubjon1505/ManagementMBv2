using ManagementMB.Enums;

namespace ManagementMB.Models
{
    public class Expenses : BaseEntity
    {
        public double Amount { get; set; }
        public  ExpenseCategory Category { get; set; }
       
    }
}
