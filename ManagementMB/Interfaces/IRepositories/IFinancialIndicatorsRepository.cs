using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface IFinancialIndicatorsRepository
    {
        public FinancialIndicators GetByDate(DateTime fromDate, DateTime toDate);
        public IQueryable<FinancialIndicators> GetAll();
        public bool Delete(Guid id);
    }
}
