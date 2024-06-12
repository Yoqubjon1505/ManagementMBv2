using ManagementMB.Enums;

namespace ManagementMB.Models
{
    public class CashFlow : BaseEntity
    {
        public double Sale { get; set; }
        public double Purchase { get; set; }
        public double GrossProfit { get; set; }
        //public Expenses Expenses { get; set; }
        //public Guid ExpensesId { get; set; }
        public double ExpensesAmount { get; set; }
        //public double Tax { get; set; }

        //ОбщиеЗатраты
        //public double TotalCosts { get; set; }
        public double NetProfit { get; set; }
      
    }
}
