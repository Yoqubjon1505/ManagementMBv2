using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface ICashFlowService
    {
        public CashFlow GetByDate(DateTime fromDate, DateTime toData);
    }
}
