using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class OrderRepository(SplitterDbContext dbContext)
: Repository<Order, Guid>(dbContext), IOrderRepository
{
    public async Task<List<Order>> Filter(DateTime? from, DateTime? to, bool withProducts, bool withVouchers)
    {
        var query = dbContext.Orders.AsQueryable();
        
        if (from.HasValue)
            query = query.Where(x => x.CreatedAt >= from);

        if (to.HasValue)
            query = query.Where(x => x.CreatedAt <= to);

        if (withProducts)
            query = query.Include(x => x.Products);
        
        if (withVouchers)
            query = query.Include(x => x.Vouchers);
            
        return  await query.ToListAsync();
    }
}
