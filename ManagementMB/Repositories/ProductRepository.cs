using ManagementMB.DTOs;
using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;

namespace ManagementMB.Repositories
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetById(Guid id)
        {

            return _context.Products.FirstOrDefault(p => p.Id == id);


        }

        public bool Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return true;
        }


        public bool Update(Guid id, Product item)
        {
            var _item = _context.Products.Find(id);
            if (_item is not null)
            {
                _context.Update(_item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            var item = _context.Products.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateForSale(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

    }
}
