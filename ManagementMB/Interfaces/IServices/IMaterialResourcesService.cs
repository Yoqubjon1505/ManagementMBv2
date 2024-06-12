using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface IMaterialResourcesService
    {
        IEnumerable<MaterialResources> GetAll();
        MaterialResources GetById(Guid id);
        MaterialResources Create(MaterialResourcesDTO entity);
        bool Update(Guid id, MaterialResourcesDTO product);
        bool Delete(Guid id);
    }
}
