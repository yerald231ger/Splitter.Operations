using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class EventTableRepository(SplitterDbContext dbContext)
: Repository<EventTable, Guid>(dbContext), IEventTableRepository
{
    SplitterDbContext SplitterDbContext { get; } = dbContext;
    
    public Task<EventTable?> GetEventTableWithOrder(Guid eventTableId)
    {
        return SplitterDbContext.EventTables
            .Include(e => e.OrderTable)
            .FirstOrDefaultAsync(e => e.Id == eventTableId);
    }
}
