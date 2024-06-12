using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;

namespace ManagementMB.Repositories
{
    public class FinancialIndicatorsRepository : IFinancialIndicatorsRepository
    {
        private readonly AppDbContext _context;
        private readonly IBalanceRepository _balanceRepository;
        private readonly ICashFlowRepository _cashFlowRepository;
        public FinancialIndicatorsRepository
            (AppDbContext context, 
            IBalanceRepository balanceRepository, 
            ICashFlowRepository cashFlowRepository)
        {
            _context = context;
            _balanceRepository = balanceRepository;
            _cashFlowRepository = cashFlowRepository;
        }
        public FinancialIndicators GetByDate(DateTime fromDate, DateTime toDate)
        {
            var balance = _balanceRepository.GetByDate(toDate);
            var cashFlow = _cashFlowRepository.GetByDate(fromDate, toDate);

            if (balance == null || cashFlow == null)
            {
                throw new Exception("Balance or CashFlow data is missing.");
            }

            // Проверки на нулевые значения, чтобы избежать деления на ноль
            var liabilities = balance.Liabilitiies != 0 ? balance.Liabilitiies : 1;
            var currentAssets = balance.CurrentAssets != 0 ? balance.CurrentAssets : 1;
            var stockProducts = balance.StockProducts != 0 ? balance.StockProducts : 1;
            var debtors = balance.Debtors != 0 ? balance.Debtors : 1;
            var sale = cashFlow.Sale != 0 ? cashFlow.Sale : 1;

            var indicators = new FinancialIndicators
            {
                Leverage = liabilities / currentAssets,
                Rotation = cashFlow.Purchase / currentAssets,
                InventoryTurnover = cashFlow.Purchase / stockProducts,
                AccountsReceivableTurnover = cashFlow.NetProfit / debtors,
                Liquidity = currentAssets / liabilities,
                Profitability = cashFlow.GrossProfit / sale,
                GrossProfit = cashFlow.GrossProfit,
                TotalExpenses = cashFlow.ExpensesAmount,
                NetProfit = cashFlow.NetProfit,
                Description =$"from {fromDate} to {toDate}"
                
            };

            _context.FinancialIndicators.Add(indicators);
            _context.SaveChanges();
            return indicators;
        }

        public IQueryable<FinancialIndicators> GetAll()
        {
           return _context.FinancialIndicators;
        }

        public bool Delete(Guid id)
        { 
         var item = _context.FinancialIndicators.FirstOrDefault(i => i.Id == id);
            if (item!=null)
            {
                _context.FinancialIndicators.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        
        }
       
        
    }
}
