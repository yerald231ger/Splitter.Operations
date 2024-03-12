using Microsoft.EntityFrameworkCore;
using Splitter.Extensions;
using Splitter.Commensality.Infrastructure;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

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
