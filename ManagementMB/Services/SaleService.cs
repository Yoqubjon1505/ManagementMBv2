using ManagementMB.DTOs;
using ManagementMB.Enums;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;
using ManagementMB.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.Services
{
    public class SaleService : ISaleService
    {
        ISaleRepository _repository;
        IProductRepository _productRepository;
        
        public SaleService
            (ISaleRepository repository, 
            IProductRepository productRepository, 
            IDebtorsRepository debtorsRepository)
        {
            _repository = repository;   
            _productRepository = productRepository;
            
        }
        public bool Create(SaleProductDTO item)
        {
           var product= _productRepository.GetById(item.ProductId);
            if (product != null & product.Quantity > 0)
            {
                var sale = new Sale
                {
                  Product = product,
                  ProductId = item.ProductId,
                  QuantitySold = item.Quantity,
                  TotalPrice=item.Price*item.Quantity,
                  Name=product.Name,
                  Description=item.Description,
                  Price=item.Price,
                };
               
                 product.TotalPrice -= item.Price*item.Quantity;
                 product.Quantity -= item.Quantity;
                 var _item = product.CostPrice * item.Quantity;
                 product.TotalCostPrice -= _item;
                _productRepository.UpdateForSale(product);
               
              _repository.Create(item.ProductId, sale);
                return true;
            }
            return false;

        }

       
        public bool DeleteSale(Guid saleId)
        {
            var sale = _repository.GetById(saleId);

            if (sale != null)
            {
                var product = _productRepository.GetById(sale.ProductId);

                if (product != null)
                {
                    product.TotalPrice += sale.TotalPrice;
                    product.Quantity += sale.QuantitySold;
                    var _item = sale.QuantitySold * product.CostPrice;
                    product.TotalCostPrice += _item;

                    _productRepository.UpdateForSale(product);
                    _repository.Delete(saleId);
                    return true;
                }
            }

            return false;
        }

        public IQueryable<Sale> GetAll()
        {
          return  _repository.GetAll();
        }

        public IQueryable<Product> GetAllProducts()
        {
           return _productRepository.GetAll();
        }

        public IQueryable<Sale> GetByDateTime(DateTime dateTime)
        {
         return   _repository.GetByDateTime(dateTime);
        }

        public Sale GetById(Guid id)
        {
           return _repository.GetById(id);
        }

        public Product GetProductById(Guid id)
        {
           return _productRepository.GetById(id);
        }

        public bool UpdateSale(Guid saleId, SaleProductDTO item)
        {
            var sale = _repository.GetById(saleId);

            if (sale != null)
            {
                var product = _productRepository.GetById(sale.ProductId);

                if (product != null)
                {
                    // Восстановить количество и цену товара по предыдущей продаже
                    product.TotalPrice += sale.TotalPrice;
                    product.Quantity += sale.QuantitySold;
                    var _item = sale.QuantitySold * product.CostPrice;
                    product.TotalCostPrice += _item;

                    // Обновить данные продажи новыми значениями
                    sale.QuantitySold = item.Quantity;
                    sale.TotalPrice = item.Price * item.Quantity;
                    sale.Name = product.Name;
                    sale.Description = item.Description;
                    sale.Price = item.Price;
                    product.TotalPrice -= item.Price * item.Quantity;
                    product.Quantity -= item.Quantity;
                    var _item2 = product.CostPrice * item.Quantity;
                    product.TotalCostPrice -= _item2;
                    sale.Product= product;

                    // Обновить товар и продажу в базе данных
                    _productRepository.UpdateForSale(product);
                    _repository.Update(saleId, item);
                    return true;
                }
            }

            return false;
        }

    }
}
