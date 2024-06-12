using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface IBalanceService
    {
        public Balance GetByDate(DateTime dateTime);
        public IQueryable<Balance> GetAllBalace();
        public bool Delete(Guid id);
    }
}
