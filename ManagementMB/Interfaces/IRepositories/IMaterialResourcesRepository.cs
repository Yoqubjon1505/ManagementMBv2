using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IRepositories
{
    public interface IMaterialResourcesRepository
    {
        public IQueryable<MaterialResources> GetAll();
        public MaterialResources GetById(Guid id);
        public bool Create(MaterialResources item);
        public bool Update(Guid id, MaterialResourcesDTO item);
        public bool Delete(Guid id);
    }
}
