using ManagementMB.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashFlowController : ControllerBase
    {
        private readonly ICashFlowService _cashFlowService;
        public CashFlowController(ICashFlowService cashFlowService)
        {
                _cashFlowService = cashFlowService;
        }


        [HttpPost("GetByDate")]
        public IActionResult GetByDate([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var item = _cashFlowService.GetByDate(fromDate, toDate);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }


    }
}
