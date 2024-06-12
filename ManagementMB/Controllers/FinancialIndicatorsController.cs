using ManagementMB.Interfaces.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialIndicatorsController : ControllerBase
    {
        IFinancialIndicatorsRepository _repository;
        public FinancialIndicatorsController(IFinancialIndicatorsRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult GetByDate(DateTime fromDate, DateTime toDate)
        {
            
            var item= _repository.GetByDate(fromDate,toDate);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _repository.Delete(id);
                return Ok("deleted");
            }
            catch (Exception)
            {

                throw new Exception($"{BadRequest()}");
            }
               
        }
    }
}
