namespace ManagementMB.Models
{
    public class FinancialIndicators: BaseEntity
    {
        public double Leverage { get; set; }
        public double Rotation { get; set; }
        public double InventoryTurnover { get; set; }
        public double AccountsReceivableTurnover { get; set; }
        public double Liquidity { get; set; }
        public double Profitability { get; set; }
        public double GrossProfit { get; set; }
        public double TotalExpenses { get; set; }
        public double NetProfit { get; set; }
    }
}
