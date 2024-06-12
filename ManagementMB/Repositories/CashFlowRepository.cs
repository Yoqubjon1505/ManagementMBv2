using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManagementMB.Repositories
{
    public class CashFlowRepository : ICashFlowRepository
    {
        private readonly AppDbContext _context;
        public CashFlowRepository(AppDbContext context)
        {
            _context = context;
        }
        public CashFlow GetByDate(DateTime fromDate, DateTime toDate)
        {
            var sale = _context.Sales
         .Where(p => p.DateTime >= fromDate && p.DateTime <= toDate)
         .Sum(p => p.Price);

            var purchase = _context.Purchases
                .Where(p => p.DateTime >= fromDate && p.DateTime <= toDate)
                .Sum(p => p.CostPrice);

            var expensesAmount = _context.Expenses
                .Where(p => p.DateTime >= fromDate && p.DateTime <= toDate)
                .Sum(mr => mr.Amount);

            var cashFlow = new CashFlow
            {
                Sale = sale,
                Purchase = purchase,
                ExpensesAmount = expensesAmount,
                Description = $"from {fromDate} to {toDate}"
            };
            _context.CashFlows.Add(cashFlow);
            _context.SaveChanges();
            return cashFlow;
        }
    }
}
