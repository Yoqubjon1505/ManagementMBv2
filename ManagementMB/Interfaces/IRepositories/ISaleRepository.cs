using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface ISaleRepository
    {
        public Sale GetById(Guid id);
        public bool Create(Guid id,Sale item);
        public bool Update(Guid id, SaleProductDTO item);
        public bool Delete(Guid id);
        public IQueryable<Sale> GetAll();
        public IQueryable<Sale> GetByDateTime(DateTime dateTime);
    }
}
