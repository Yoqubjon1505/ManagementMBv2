using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Services
{
    public class BalanceService : IBalanceService
    {
        IBalanceRepository _balanceRepository;
    
        public BalanceService(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public bool Delete(Guid id)
        {
            var balance = _balanceRepository.Delete(id);
            if (balance!=false)
            {
            _balanceRepository.Delete(id);
                return true;
            }
            return false;
        }

        public IQueryable<Balance> GetAllBalace()
        {
            return _balanceRepository.GetAllBalance();
        }

        public Balance GetByDate(DateTime dateTime)
        {


          var balance =  _balanceRepository.GetByDate(dateTime);
            if (balance != null)
            {
                balance.CurrentAssets = balance.Availability + balance.Debtors + balance.StockProducts;
                balance.FixedAssets = balance.Transport + balance.Building + balance.Equipment;
                balance.Capital = balance.CurrentAssets + balance.FixedAssets - balance.Liabilitiies;
            
                return balance;
            }
            return null;
        }
    }
}
