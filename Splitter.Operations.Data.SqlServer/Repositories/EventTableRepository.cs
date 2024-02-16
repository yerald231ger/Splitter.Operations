using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class EventTableRepository(SplitterDbContext dbContext)
: Repository<EventTable, Guid>(dbContext), IEventTableRepository
{
    SplitterDbContext SplitterDbContext { get; } = dbContext;
    
    public async Task<EventTable?> GetEventTableWithOrder(Guid eventTableId)
    {
        var eventTable = await SplitterDbContext.EventTables
            .Include(e => e.OrderTable)
            .FirstOrDefaultAsync(e => e.Id == eventTableId);

        if (eventTable?.OrderTable != null)
        {
            eventTable.OrderTable.Products = await SplitterDbContext.Products
                .Where(p => p.OrderTableId == eventTable.OrderTable.Id)
                .ToListAsync();

            eventTable.OrderTable.Vouchers = await SplitterDbContext.Vouchers
                .Where(v => v.OrderTableId == eventTable.OrderTable.Id)
                .ToListAsync();
        }

        return eventTable;
    }
}
