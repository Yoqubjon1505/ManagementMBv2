using ManagementMB.Enums;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;

namespace ManagementMB.Services
{
    public class CashFlowService : ICashFlowService
    {
        ICashFlowRepository _repository;
        public CashFlowService(ICashFlowRepository repository)
        {
            _repository = repository;
        }
        public CashFlow GetByDate(DateTime fromDate, DateTime toDate)
        {
            var _item = _repository.GetByDate(fromDate, toDate);

            if (_item != null)
            {
                _item.GrossProfit = _item.Sale - _item.Purchase;
                _item.NetProfit = _item.GrossProfit - _item.ExpensesAmount;

                return _item;
            }

            return null;
        }
    }
}
