using ManagementMB.DTOs;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService= productService;
        }
        [HttpGet]
        public async  Task<IEnumerable<Product>> Get()
        {
            return  _productService.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody]ProductDTO product)
        {
           _productService.Create(product);
            return Ok(product);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery]Guid id,[FromBody]Product product)
        {
           var item = _productService.GetById(id);
            if (item != null)
            {
                _productService.Update(item.Id, product);
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery]Guid id)
        {
            var product = _productService.GetById(id);
            if (product !=null)
            {
                _productService.Delete(id);
                return Ok("Deleted");
            }
            return BadRequest();
        }
        [HttpGet("GetById")]
        public ActionResult<Product> GetById([FromQuery] Guid id) 
        {
            return Ok(_productService.GetById(id));
        }
    }
}
