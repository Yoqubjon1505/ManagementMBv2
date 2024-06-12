using ManagementMB.CQRS.Commands;
using ManagementMB.Infrastructure;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.CQRS.Handlers
{
    public class CreateWorkerCommandHandler
    {
        private readonly AppDbContext _context;

        public CreateWorkerCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateWorkerCommand command)
        {
            var worker = new Worker
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserStatus = command.UserStatus,
            };
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
        }
    }
}
