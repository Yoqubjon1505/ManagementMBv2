using ManagementMB.DTOs;
using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        AppDbContext _context;
        public SaleRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Create(Guid id, Sale item)
        {
            var product=_context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null & product.Quantity > 0)
            {
                _context.Sales.Add(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            var item= _context.Sales.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<Sale> GetAll()
        {
          return  _context.Sales;
        }

        public IQueryable<Sale> GetByDateTime(DateTime dateTime)
        {
          return  _context.Sales.Where(p => p.DateTime == dateTime);
        }

        public Sale GetById(Guid id)
        {
          return _context.Sales.Find(id);    
        }

        public bool Update(Guid id, SaleProductDTO item)
        {
           var _item = _context.Sales.Find(id);
            if (_item != null && item.Quantity>0)
            {
               _context.Sales.Update(_item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
