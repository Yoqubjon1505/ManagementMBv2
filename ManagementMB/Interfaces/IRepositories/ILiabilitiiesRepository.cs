using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface ILiabilitiiesRepository
    {
        public IQueryable<Liabilitiies> GetAll();
        public Liabilitiies GetById(Guid id);
        public bool Create(LiabilitiiesDTO item);
        public bool Update(Guid id, LiabilitiiesDTO item);
        public bool Delete(Guid id);

    }
}
