using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface IExpensesRepository
    {
        public Expenses GetById(Guid id);
        public bool Create(Expenses item);
        public bool Update(Guid id, ExpenseDto item);
        public bool Delete(Guid id);
        public IQueryable<Expenses> GetAll();
        public IQueryable<Expenses> GetByDateTime(DateTime dateTime);
    }
}
