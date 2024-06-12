using ManagementMB.CQRS.Queries.Query_Models;
using ManagementMB.Infrastructure;
using ManagementMB.Models;

namespace ManagementMB.CQRS.Queries.Query_Handlers
{
    public class GetWorkerByIdQueryHandler
    {
        private readonly AppDbContext _context;

        public GetWorkerByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Worker> Handle(GetWorkerByIdQuery query)
        {
            return await _context.Workers.FindAsync(query.Id);
        }
    }
}
