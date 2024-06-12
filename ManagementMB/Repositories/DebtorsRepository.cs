using ManagementMB.DTOs;
using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;

namespace ManagementMB.Repositories
{
    public class DebtorsRepository : IDebtorsRepository
    {
        private readonly AppDbContext _context;
        public DebtorsRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Create(DebtorsDTO item)
        {
            var _item = new Debtors 
            {
                Amount = item.Amount,
                Description=item.Description,
                Name = item.Name,
                DateTime= DateTime.Now,
            };

            _context.Debtors.Add(_item);  
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Guid id)
        {
            var _item = _context.Debtors.FirstOrDefault(_ => _.Id == id);
            if (_item != null)
            {
                _context.Remove(_item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IQueryable<Debtors> GetAll()
        {
           return _context.Debtors;
        }

        public Debtors GetById(Guid id)
        {
           var _item = _context.Debtors.FirstOrDefault(_=>_.Id==id);
            if (_item!=null)
            {
                return _item;
            }
            return null;
        }

        public bool Update(Guid id, DebtorsDTO item)
        {
            var _item = _context.Debtors.FirstOrDefault(_ => _.Id == id);
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
