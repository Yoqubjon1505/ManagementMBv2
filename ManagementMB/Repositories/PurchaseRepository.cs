using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Repositories
{
    public class PurchaseRepository: IPurchaseRepository
    {
        AppDbContext _appDbContext;
        public PurchaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Create(Purchase item)
        {
            _appDbContext.Purchases.Add(item);
            _appDbContext.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
           var item =_appDbContext.Purchases.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _appDbContext.Remove(item);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<Purchase> GetAll()
        {
           return _appDbContext.Purchases;
        }

        public IQueryable<Purchase> GetByDateTime(DateTime dateTime)
        {
           var item= _appDbContext.Purchases.Where(p => p.DateTime == dateTime);
            if (item!=null)
            {
                return item;
            }
            else return null;
        }

        public Purchase GetById(Guid id)
        {
           var item= _appDbContext.Purchases.FirstOrDefault(p=>p.Id==id);
            if (item != null)
            { 
            return item;
            }
            else
            {
                return null;
            }
        
        }

        public bool Update(Guid id, Purchase item)
        {
           var _item= _appDbContext.Purchases.FirstOrDefault(p => p.Id == id);
            if (_item!=null)
            {
                _appDbContext.Update(_item);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
