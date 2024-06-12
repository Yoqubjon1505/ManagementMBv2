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


        [HttpPost("GetByData")]
        public IActionResult GetByData([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
           var _item = _cashFlowService.GetByDate(fromDate, toDate);
            if (_item != null)
            {
                return Ok(_item);
            }
            return NotFound();

        }

    }
}
