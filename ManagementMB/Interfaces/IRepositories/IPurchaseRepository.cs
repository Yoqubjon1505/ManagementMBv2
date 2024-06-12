using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface IPurchaseRepository
    {
        public Purchase GetById(Guid id);
        public bool Create(Purchase item);
        public bool Update(Guid id, Purchase item);
        public bool Delete(Guid id);
        public IQueryable<Purchase> GetAll();
        public IQueryable<Purchase> GetByDateTime(DateTime dateTime);
    }
}
