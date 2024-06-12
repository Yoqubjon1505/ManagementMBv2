using ManagementMB.DTOs;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;
using System.Security.Cryptography.Xml;

namespace ManagementMB.Services
{
    public class MaterialResourcesService : IMaterialResourcesService
    {
        IMaterialResourcesRepository _repository;
        public MaterialResourcesService(IMaterialResourcesRepository repository)
        {
                _repository = repository;   
        }
        public MaterialResources Create(MaterialResourcesDTO entity)
        {
            var item = new MaterialResources
            {
                Name = entity.Name,
                Description = entity.Description,
                Building   = entity.Building,
                Transport=entity.Transport,
                Equipment=entity.Equipment,
                DateTime=DateTime.Now,
            };
            _repository.Create(item);
            return item;
        }

        public bool Delete(Guid id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                _repository.Delete(item.Id);
                return true;
            }
            return false;
        }

        public IEnumerable<MaterialResources> GetAll()
        {
            return _repository.GetAll();
        }

        public MaterialResources GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool Update(Guid id, MaterialResourcesDTO entity)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                item.Name= entity.Name;
                item.Description = entity.Description;
                item.Building = entity.Building;
                item.Transport = entity.Transport;
                item.Equipment = entity.Equipment;
                _repository.Update(id, entity);
                return true;
            }
            return false;
        }
       
    }
}
