using ManagementMB.DTOs;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiabilitiiesController : ControllerBase
    {
        private readonly  ILiabilitiiesRepository _repository;
        public LiabilitiiesController(ILiabilitiiesRepository repository)
        {
                _repository = repository;
        }
        
        [HttpGet]
        public IQueryable<Liabilitiies> Get()
        {
            return _repository.GetAll().AsQueryable();
        }

        [HttpPost]
        public IActionResult Create([FromBody] LiabilitiiesDTO entity)
        {
            _repository.Create(entity);
            return Ok(entity);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] Guid id, [FromBody] LiabilitiiesDTO entity)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                _repository.Update(item.Id, entity);
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Guid id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                _repository.Delete(id);
                return Ok("Deleted");
            }
            return BadRequest();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_repository.GetById(id));
        }
    }
}
