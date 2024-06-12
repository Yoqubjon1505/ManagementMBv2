using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface IPurchaseService 
    {
        public Purchase GetById(Guid id);
        public IQueryable<Purchase> GetAll();
        public IQueryable<Purchase> GetByDateTime(DateTime dateTime);
        public bool CreatePurchase(Guid id, ProductDTO item);
        public bool UpdatePurchase(Guid id, ProductDTO item);
        public bool DeletePurchase(Guid id);
    }
}
