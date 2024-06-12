using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface ICashFlowRepository
    {
        public CashFlow GetByDate(DateTime fromDate, DateTime toDate);
    }
}
