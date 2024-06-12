using ManagementMB.DTOs;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialResourcesController : ControllerBase
    {
        IMaterialResourcesService _service;
        public MaterialResourcesController(IMaterialResourcesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IQueryable<MaterialResources> Get()
        {
            return _service.GetAll().AsQueryable();
        }

        [HttpPost]
        public IActionResult Create([FromBody] MaterialResourcesDTO product)
        {
            _service.Create(product);
            return Ok(product);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] Guid id, [FromBody] MaterialResourcesDTO product)
        {
            var item = _service.GetById(id);
            if (item != null)
            {
                _service.Update(item.Id, product);
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var product = _service.GetById(id);
            if (product != null)
            {
                _service.Delete(id);
                return Ok("Deleted");
            }
            return BadRequest();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_service.GetById(id));
        }
    }
}
