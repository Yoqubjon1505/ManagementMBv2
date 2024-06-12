using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly AppDbContext _context;
        public BalanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public Balance GetByDate(DateTime date)
        {
            var stockProducts = _context.Products
                .Where(p => p.DateTime <= date) // Учитываем только продукты, созданные до или включительно нашей запрошенной даты
                .Sum(p => p.TotalCostPrice);
            var saleProduct = _context.Sales
                .Where(p => p.DateTime <= date)
                .Sum (p => p.TotalPrice);
            var debtors = _context.Debtors
                .Where(p => p.DateTime <= date)
                .Sum(p => p.Amount);

            var transport = _context.MaterialResources
                .Where(mr => mr.DateTime <= date)
                .Sum(mr => mr.Transport);

            var building = _context.MaterialResources
                .Where(mr => mr.DateTime <= date)
                .Sum(mr => mr.Building);
            
            var equipment = _context.MaterialResources
                .Where (mr => mr.DateTime <= date)
                .Sum(mr => mr.Equipment);
            
            var liabilitiies = _context.Liabilitiies
                .Where(mr => mr.DateTime <= date)
                .Where(mr => mr.DateTime <= date)
                .Sum(mr=>mr.Amount);

            var balance = new Balance
            {
                Availability = saleProduct,
                Debtors= debtors,
                StockProducts = stockProducts,
                Transport = transport,
                Building = building,
                Equipment = equipment,
                Liabilitiies = liabilitiies,
            };
            _context.Balances.Add(balance);
            _context.SaveChanges();
            return balance;
        }

        public IQueryable<Balance> GetAllBalance()
        {
           return _context.Balances;
        }

        public bool Delete(Guid id)
        {
           var _item= _context.Balances.FirstOrDefault(_=>_.Id==id);
            if (_item!=null)
            {
                _context.Remove(_item);
                _context.SaveChanges();
                return true;    
            }
            return false;
        }


    }   
}
