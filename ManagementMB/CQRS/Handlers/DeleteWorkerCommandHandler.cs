using ManagementMB.CQRS.Commands;
using ManagementMB.Infrastructure;

namespace ManagementMB.CQRS.Handlers
{
    public class DeleteWorkerCommandHandler
    {
        private readonly AppDbContext _context;

        public DeleteWorkerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteWorkerCommand command)
        {
            var worker = await _context.Workers.FindAsync(command.Id);
            if (worker == null) throw new Exception("worker not found");

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
        }
    }
}
