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
            .Include(e => e.Order)
            .FirstOrDefaultAsync(e => e.Id == eventTableId);

        if (eventTable?.Order != null)
        {
            eventTable.Order.Products = await SplitterDbContext.Products
                .Where(p => p.OrderId == eventTable.Order.Id)
                .ToListAsync();

            eventTable.Order.Vouchers = await SplitterDbContext.Vouchers
                .Where(v => v.OrderTableId == eventTable.Order.Id)
                .ToListAsync();
        }

        return eventTable;
    }
}
