using ManagementMB.DTOs;
using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Repositories
{
    public class MaterialResourcesRepository : IMaterialResourcesRepository
    {
       private readonly AppDbContext _context;
        public MaterialResourcesRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<MaterialResources> GetAll()
        {
            return _context.MaterialResources;
        }

        public MaterialResources GetById(Guid id)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is not initialized.");
            }

            var resource = _context.MaterialResources.SingleOrDefault(p => p.Id == id);
            if (resource == null)
            {
                throw new KeyNotFoundException($"MaterialResource with ID {id} was not found.");
            }

            return resource;
        }


        public bool Create(MaterialResources item)
        {
            _context.MaterialResources.Add(item);
            _context.SaveChanges();
            return true;
        }


        public bool Update(Guid id, MaterialResourcesDTO item)
        {
            var _item = _context.MaterialResources.Find(id);
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
            var item = _context.MaterialResources.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _context.MaterialResources.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateForSale(MaterialResources product)
        {
            _context.MaterialResources.Update(product);
            _context.SaveChanges();
        }
    }
}
