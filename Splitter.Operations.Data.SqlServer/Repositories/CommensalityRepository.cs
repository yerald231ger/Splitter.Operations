using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class CommensalityRepository(SplitterDbContext dbContext)
: Repository<Commensality, Guid>(dbContext), ICommensalityRepository
{
    SplitterDbContext SplitterDbContext { get; } = dbContext;
    
    public async Task<Commensality?> GetCommensalityWithOrder(Guid commensalityId)
    {
        var commensality = await SplitterDbContext.Commensalitys
            .Include(e => e.Order)
            .FirstOrDefaultAsync(e => e.Id == commensalityId);

        if (commensality?.Order != null)
        {
            commensality.Order.Products = await SplitterDbContext.Products
                .Where(p => p.OrderId == commensality.Order.Id)
                .ToListAsync();

            commensality.Order.Vouchers = await SplitterDbContext.Vouchers
                .Where(v => v.OrderId == commensality.Order.Id)
                .ToListAsync();
        }

        return commensality;
        
    }
}
