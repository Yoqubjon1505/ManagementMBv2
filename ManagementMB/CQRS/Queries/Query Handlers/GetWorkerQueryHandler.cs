using ManagementMB.Infrastructure;
using ManagementMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementMB.CQRS.Queries.Query_Handlers
{
    public class GetWorkerQueryHandler
    {
        private readonly AppDbContext _context;

        public GetWorkerQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Worker>> Handle(GetWorkerQuery query)
        {
            return await _context.Workers.ToListAsync();
        }
    }
}
