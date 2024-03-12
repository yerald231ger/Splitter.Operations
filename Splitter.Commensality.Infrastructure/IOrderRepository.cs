using Splitter.Extensions;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Infrastructure;

public interface IOrderRepository : IRepository<Order, Guid>
{
    Task<List<OrderProduct>?> GetProducts(Guid id);
    Task<List<Voucher>?> GetVouchers(Guid id);
}
