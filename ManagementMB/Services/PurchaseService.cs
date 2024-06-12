using ManagementMB.DTOs;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;

namespace ManagementMB.Services
{
    public class PurchaseService : IPurchaseService
    {
        IPurchaseRepository _repository;
        IProductRepository _productRepository;
        IProductService _productService;

        public PurchaseService(IPurchaseRepository repository, IProductRepository productRepository, IProductService productService)
        {
            _repository = repository;
            _productRepository = productRepository;
            _productService = productService;
        }

        public bool CreatePurchase(Guid id, ProductDTO item)
        {
            var product = _productRepository.GetById(id);

            if (product == null||product.CostPrice!=item.CostPrice||product.Price!=item.Price)
            {
                // Создать новый товар, если он не найден
                var newProduct = _productService.Create(item);
                var purchase1 = new Purchase
                {
                    Product = newProduct,
                    ProductId = newProduct.Id, // Используем новый идентификатор продукта
                    Quantity = item.Quantity,
                    TotalPrice = item.Price * item.Quantity,
                    Name = newProduct.Name, // Здесь должно быть newProduct.Name, а не product.Name
                    Description = item.Description,
                    Price = item.Price,
                    CostPrice = item.Price,
                    TotalCostPrice = item.CostPrice*item.Quantity,
                    
                };
               
                _repository.Create(purchase1);
                return true;
            }
            else
            {
                // Обновить существующий товар
                product.TotalPrice += item.Price * item.Quantity;
                product.Quantity += item.Quantity;
                var _item = product.CostPrice * item.Quantity;
                product.TotalCostPrice += _item;
                _productRepository.UpdateForSale(product);

                var purchase = new Purchase
                {
                    Product = product,
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    TotalPrice = item.Price * item.Quantity,
                    Name = product.Name,
                    Description = item.Description,
                    Price = item.Price,
                    CostPrice = item.Price,
                    TotalCostPrice= item.CostPrice*item.Quantity,
                };
                _repository.Create(purchase);
                return true;
            }
        }


        public bool DeletePurchase(Guid purchaseId)
        {
            var purchase = _repository.GetById(purchaseId);

            if (purchase != null)
            {
                var product = _productRepository.GetById(purchase.ProductId);

                if (product != null)
                {
                    product.TotalPrice -= purchase.TotalPrice;
                    product.Quantity -= purchase.Quantity;
                    var _item = purchase.Quantity * product.CostPrice;
                    product.TotalCostPrice -= _item;

                    _productRepository.UpdateForSale(product);
                    _repository.Delete(purchaseId);
                    return true;
                }
            }

            return false;
        }

        public IQueryable<Purchase> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Purchase> GetByDateTime(DateTime dateTime)
        {
            return _repository.GetByDateTime(dateTime);
        }

        public Purchase GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public bool UpdatePurchase(Guid purchaseId, ProductDTO item)
        {
            var purchase = _repository.GetById(purchaseId);

            if (purchase != null)
            {
                var product = _productRepository.GetById(purchase.ProductId);

                if (product != null)
                {
                    // Восстановить количество и цену товара по предыдущей покупке
                    product.TotalPrice -= purchase.TotalPrice;
                    product.Quantity -= purchase.Quantity;
                    var _item = purchase.Quantity * product.CostPrice;
                    product.TotalCostPrice -= _item;

                    // Обновить данные покупки новыми значениями
                    purchase.Quantity = item.Quantity;
                    purchase.TotalPrice = item.Price * item.Quantity;
                    purchase.Name = product.Name;
                    purchase.Description = item.Description;
                    purchase.Price = item.Price;
                    product.TotalPrice += item.Price * item.Quantity;
                    product.Quantity += item.Quantity;
                    var _item2 = product.CostPrice * item.Quantity;
                    product.TotalCostPrice += _item2;
                    purchase.Product = product;

                    // Обновить товар и покупку в базе данных
                    _productRepository.UpdateForSale(product);
                    _repository.Update(purchaseId, purchase);
                    return true;
                }
            }

            return false;
        }
    }


}
