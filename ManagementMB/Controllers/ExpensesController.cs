using ManagementMB.DTOs;
using ManagementMB.Enums;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExpenseDto item)
        {
            if (item == null)
            {
                return BadRequest("Expense item is null.");
            }

            var createdItem = _expensesService.CreateExpenses(item);

            if (createdItem != null)
            {
                return Ok(createdItem);
            }
            return BadRequest("Failed to create expense.");
        }
        [HttpPut]
        public IActionResult UpdateExpenses([FromQuery] Guid id, [FromBody] ExpenseDto item)
        {
            var _tem = _expensesService.GetById(id);
            if (_tem != null)
            {
                return Ok(_expensesService.UpdateExpenses(id, item));
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteSale([FromQuery] Guid id)
        {
            var _item = _expensesService.GetById(id);
            if (_item != null)
            {
                return Ok(_expensesService.DeleteExpenses(_item.Id));

            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public IActionResult GetExpensesById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }

            var item = _expensesService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet("GetDataTime")]
        public IActionResult GetByDateTime(DateTime dateTime)
        {
            var item = _expensesService.GetByDateTime(dateTime);

            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_expensesService.GetAll());

        }

        [HttpGet("GetByCategory")]
        public IActionResult GetByCategory(ExpenseCategory category)
        {
            var _item = _expensesService.GetByCategory(category);
            if (_item != null)
            {
                return Ok(_item);
            }
            return NotFound();
        }
    }
}
