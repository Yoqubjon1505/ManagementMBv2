using ManagementMB.DTOs;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpPost]
        public IActionResult Create([FromQuery] Guid id, [FromBody] ProductDTO productDTO)
        { 
           
           return Ok(_purchaseService.CreatePurchase(id, productDTO));

        }
        [HttpPut]
        public IActionResult UpdatePurchase([FromQuery] Guid id, [FromBody] ProductDTO item)
        {
            var _tem = _purchaseService.GetById(id);
            if (_tem != null)
            {
                return Ok(_purchaseService.UpdatePurchase(id, item));
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeletePurchase([FromQuery] Guid id)
        {
            var _item = _purchaseService.GetById(id);
            if (_item != null)
            {
                return Ok(_purchaseService.DeletePurchase(_item.Id));

            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public IActionResult GetPurchaseById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }

            var item = _purchaseService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet("GetDataTime")]
        public IActionResult GetByDateTime(DateTime dateTime)
        {
            var item = _purchaseService.GetByDateTime(dateTime);

            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_purchaseService.GetAll());
        }
    }
}
