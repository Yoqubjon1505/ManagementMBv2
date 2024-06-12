using ManagementMB.CQRS.Commands;
using ManagementMB.CQRS.Handlers;
using ManagementMB.CQRS.Queries;
using ManagementMB.CQRS.Queries.Query_Handlers;
using ManagementMB.CQRS.Queries.Query_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly CreateWorkerCommandHandler _createHandler;
        private readonly UpdateWorkerCommandHandler _updateHandler;
        private readonly DeleteWorkerCommandHandler _deleteHandler;
        private readonly GetWorkerQueryHandler _getAllHandler;
        private readonly GetWorkerByIdQueryHandler _getByIdHandler;
        public WorkerController(
            CreateWorkerCommandHandler createHandler,
            UpdateWorkerCommandHandler updateHandler,
            DeleteWorkerCommandHandler deleteHandler,
            GetWorkerQueryHandler getAllHandler,
            GetWorkerByIdQueryHandler getByIdHandler
            )
        {
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _getAllHandler = getAllHandler;
            _getByIdHandler = getByIdHandler;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetWorkerQuery();
            var worker = await _getAllHandler.Handle(query);
            return Ok(worker);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetWorkerByIdQuery { Id = id };
            var worker = await _getByIdHandler.Handle(query);
            if (worker == null) return NotFound();
            return Ok(worker);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWorkerCommand command)
        {
            await _createHandler.Handle(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateWorkerCommand command)
        {
            command.Id = id;
            await _updateHandler.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteWorkerCommand { Id = id };
            await _deleteHandler.Handle(command);
            return NoContent();
        }



    }
}
