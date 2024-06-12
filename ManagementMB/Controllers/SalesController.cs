using ManagementMB.DTOs;
using ManagementMB.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] SaleProductDTO item)
        {
            if (item == null || item.ProductId == Guid.Empty)
            {
                return BadRequest("Invalid sale data.");
            }

            var createdSale = _saleService.Create(item);

            if (createdSale != null)
            {
                return Ok(createdSale);
            }

            return BadRequest("Could not create sale.");
        }
        [HttpPut]
        public IActionResult UpdateSale([FromQuery]Guid id,[FromQuery] SaleProductDTO item)
        {
            var _tem = _saleService.GetById(id);
            if (_tem != null)
            {
                return Ok(_saleService.UpdateSale(id, item));
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteSale([FromQuery] Guid id)
        {
            var _item = _saleService.GetById(id);
            if (_item != null)
            {
                return Ok(_saleService.DeleteSale(_item.Id));

            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public IActionResult GetSaleById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }

            var item = _saleService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet("GetDataTime")]
        public IActionResult GetByDateTime(DateTime dateTime)
        {
            var item = _saleService.GetByDateTime(dateTime);
            
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_saleService.GetAll());
        }
        [HttpGet("GetProductById")]
        public IActionResult GetProductById(Guid productId)
        {
            var product = _saleService.GetProductById(productId); // Предполагается, что этот метод существует в ISaleService.
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _saleService.GetAllProducts(); // Предполагается, что этот метод существует в ISaleService.
            return Ok(products);
        }


    }

}
