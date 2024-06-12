using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface IBalanceRepository
    {
        public IQueryable<Balance> GetAllBalance();
        public bool Delete(Guid id);
        public Balance GetByDate(DateTime date);
    }
}
