using ManagementMB.DTOs;
using ManagementMB.Enums;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface IExpensesService
    {
        public Expenses GetById(Guid id);
        public IQueryable<Expenses> GetAll();
        public IQueryable<Expenses> GetByDateTime(DateTime dateTime);
        public IQueryable<Expenses> GetByCategory(ExpenseCategory item);
        public Expenses CreateExpenses(ExpenseDto item);
        public bool UpdateExpenses(Guid id, ExpenseDto item);
        public bool DeleteExpenses(Guid id);

    }
}
