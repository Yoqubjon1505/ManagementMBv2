using ManagementMB.DTOs;
using ManagementMB.Interfaces.IRepositories;
using ManagementMB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtorController : ControllerBase
    {
        private readonly IDebtorsRepository _repository;
        public DebtorController(IDebtorsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IQueryable<Debtors> Get()
        {
            return _repository.GetAll().AsQueryable();
        }

        [HttpPost]
        public IActionResult Create([FromBody] DebtorsDTO entity)
        {
            _repository.Create(entity);
            return Ok(entity);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery] Guid id, [FromBody] DebtorsDTO entity)
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
        public IActionResult Delete([FromQuery] Guid id)
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

