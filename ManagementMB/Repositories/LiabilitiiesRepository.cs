using ManagementMB.DTOs;
using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;

namespace ManagementMB.Repositories
{
    public class LiabilitiiesRepository : ILiabilitiiesRepository
    {
        private readonly AppDbContext _context;
        public LiabilitiiesRepository(AppDbContext context)
        {
                _context = context; 
        }
        public bool Create(LiabilitiiesDTO item)
        {
            var _item = new Liabilitiies
            {
                Amount = item.Amount,
                Description = item.Description,
                Name = item.Name,
                DateTime = DateTime.Now,
            };

            _context.Liabilitiies.Add(_item);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var _item = _context.Liabilitiies.FirstOrDefault(_ => _.Id == id);
            if (_item != null)
            {
                _context.Remove(_item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<Liabilitiies> GetAll()
        {
            return _context.Liabilitiies;
        }

        public Liabilitiies GetById(Guid id)
        {
            var _item = _context.Liabilitiies.FirstOrDefault(_ => _.Id == id);
            if (_item != null)
            {
                return _item;
            }
            return null;
        }

        public bool Update(Guid id, LiabilitiiesDTO item)
        {
            var _item = _context.Liabilitiies.FirstOrDefault(_ => _.Id == id);
            if (_item != null)
            {
                _item.Description = item.Description;
                _item.Name = item.Name;
                _item.Amount = item.Amount;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
