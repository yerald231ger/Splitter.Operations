using Microsoft.EntityFrameworkCore;
using Splitter.Extensions;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class OrderRepository(SplitterDbContext dbContext)
: Repository<Order, Guid>(dbContext), IOrderRepository
{
    private readonly SplitterDbContext _dbContext = dbContext;
    public async Task<List<OrderProduct>?> GetProducts(Guid id)
    {
        return await _dbContext.Products.Where(p => p.OrderId == id).ToListAsync();
    }

    public async Task<List<Voucher>?> GetVouchers(Guid id)
    {
        return await _dbContext.Vouchers.Where(v => v.OrderId == id).ToListAsync();
    }
}
