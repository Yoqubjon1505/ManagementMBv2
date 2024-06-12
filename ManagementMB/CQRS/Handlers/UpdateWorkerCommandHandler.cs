using ManagementMB.CQRS.Commands;
using ManagementMB.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.CQRS.Handlers
{
    public class UpdateWorkerCommandHandler
    {
       private readonly AppDbContext _context;

        public UpdateWorkerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateWorkerCommand command)
        {
            var worker = await _context.Workers.FindAsync(command.Id);
            if (worker == null) throw new Exception("worker not found");

            worker.FirstName = command.FirstName;
            worker.LastName = command.LastName;
            worker.UserStatus = command.UserStatus;

            await _context.SaveChangesAsync();
        }
    }
}
