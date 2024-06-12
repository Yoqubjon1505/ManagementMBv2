using ManagementMB.DTOs;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface IDebtorsRepository
    {
        public IQueryable<Debtors> GetAll();
        public Debtors GetById(Guid id);
        public bool Create(DebtorsDTO item);
        public bool Update(Guid id, DebtorsDTO item);
        public bool Delete(Guid id);
               

    }
}
