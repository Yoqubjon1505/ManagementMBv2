using ManagementMB.DTOs;
using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;

namespace ManagementMB.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
       private readonly AppDbContext _context;
        public ExpensesRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Create(Expenses item)
        {
            try
            {
                _context.Expenses.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Логирование ошибки, если необходимо
                throw new Exception($"Ошибка при сохранении данных: {ex.Message}");

            }
        }

        public bool Delete(Guid id)
        {
          
                var item = _context.Expenses.Find(id);
                if (item != null)
                {
                _context.Expenses.Remove(item);
                _context.SaveChanges();
                return true;
               
                }

            return false;
        }


        public IQueryable<Expenses> GetAll()
        {
            return _context.Expenses;
        }

        public IQueryable<Expenses> GetByDateTime(DateTime dateTime)
        {
          return _context.Expenses.Where(p => p.DateTime == dateTime);
        }

        public Expenses GetById(Guid id)
        {
            return _context.Expenses.Find(id);
        }

        public bool Update(Guid id, ExpenseDto item)
        {
            var _item = _context.Expenses.Find(id);
            if (_item != null)
            {
                _context.Expenses.Update(_item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
