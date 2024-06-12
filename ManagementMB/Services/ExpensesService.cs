using ManagementMB.DTOs;
using ManagementMB.Enums;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;

namespace ManagementMB.Services
{
    public class ExpensesService : IExpensesService
    {
       private readonly IExpensesRepository _repository;
        public ExpensesService(IExpensesRepository repository)
        {
            _repository = repository;
        }
        public Expenses CreateExpenses(ExpenseDto item)
        {
            var _item = new Expenses
            { 
            Amount = item.Amount,
            Category = item.Category,
            Description = item.Description    
            };
            _repository.Create(_item);
            return _item;
        }
        public bool DeleteExpenses(Guid id)
        {
            var _item = _repository.GetById(id);
            if (_item!= null)
            {
                _repository.Delete(id);
                return true;
            }
            return false;
        }

        public IQueryable<Expenses> GetAll()
        {
           return _repository.GetAll();
        }

        public IQueryable<Expenses> GetByDateTime(DateTime dateTime)
        {
           return _repository.GetByDateTime(dateTime);
        }

        public Expenses GetById(Guid id)
        {
            var _item = _repository.GetById(id);
            if (_item!=null)
            {
                return _item;
            }
            return _item;
        }
        IQueryable<Expenses> IExpensesService.GetByCategory(ExpenseCategory item)
        {
            var _item = _repository.GetAll();
            if (_item != null)
            {
               return _item.Where(x => x.Category==item);
            }
            return null;
        }

        public bool UpdateExpenses(Guid id, ExpenseDto item)
        {
            var _item = _repository.GetById(id);
            if (_item!= null)
            {
                _item.Amount = item.Amount;
                _item.Description = item.Description;
                _item.Category = item.Category;
                _repository.Update(id,item);
                return true;
            }
            return false;
        }

       
    }
}
