using ManagementMB.Infrastructure;
using ManagementMB.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;
        private readonly AppDbContext _dbContext;
        public BalanceController(IBalanceService balanceService, AppDbContext dbContext)
        {
            _balanceService = balanceService;
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult GetBalanceByDateTime([FromBody]DateTime dateTime)
        {
          var balance =  _balanceService.GetByDate(dateTime);
            if (balance!=null)
            {
                return Ok(balance);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var item = _dbContext.Balances;
            return Ok(item); 
        }
        [HttpDelete] 
        public IActionResult Delete(Guid id)
        {
          var item=  _dbContext.Balances.FirstOrDefault(c=>c.Id==id);
            if (item is not null)
            {
                _dbContext.Remove(item);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("delete-multiple")]
        public IActionResult DeleteMultiple([FromBody] List<Guid> ids)
        {
            var items = _dbContext.Balances.Where(c => ids.Contains(c.Id)).ToList();
            if (items.Count > 0)
            {
                _dbContext.Balances.RemoveRange(items);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
