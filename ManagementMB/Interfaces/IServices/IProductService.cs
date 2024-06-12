using ManagementMB.DTOs;
using ManagementMB.Models;

namespace ManagementMB.Interfaces.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        Product Create(ProductDTO entity);
        bool Update(Guid id, Product product);
        bool Delete(Guid id);
        public void UpdateForPurchase(Guid id, Product entity);
        //public void UpdateForSale(Product product);

    }
}
