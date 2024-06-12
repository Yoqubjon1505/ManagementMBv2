using ManagementMB.DTOs;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;

namespace ManagementMB.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;
        public ProductService(IProductRepository repository )
        {
            _repository = repository;
        }
        public Product Create(ProductDTO entity)
        {
            var item = new Product
            { 
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                CostPrice = entity.CostPrice,
                Quantity = entity.Quantity,
                TotalCostPrice=entity.CostPrice*entity.Quantity,
                TotalPrice=entity.Price*entity.Quantity,
                Availability=true

            };
            _repository.Create(item);
            return item;
        }

        public bool Delete(Guid id)
        {
           var item = _repository.GetById(id);
            if (item!=null)
            {
                _repository.Delete(item.Id);
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();    
        }

        public Product GetById(Guid id)
        {
           return _repository.GetById(id);
        }

        public bool Update(Guid id,Product entity)
        {
            var item = _repository.GetById(id);
            if(item!=null)
            {
                item.Name = entity.Name;
                item.Description = entity.Description;
                item.Price = entity.Price;
                item.CostPrice = entity.CostPrice;
                item.Quantity = entity.Quantity;
                item.Availability = true;
                _repository.Update(id, entity);
                return true;
            }
            return false ;
        }
        public void UpdateForPurchase(Guid id, Product entity)
        {
            var item = _repository.GetById(id);
            item.Price += entity.Price;
            item.CostPrice += entity.CostPrice;
            item.Quantity += entity.Quantity;
            _repository.Update(id, entity);
        }

       
    }
}
