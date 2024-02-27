using Splitter.Extensions;
using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IOrderRepository : IRepository<Order, Guid>
{
    Task<List<OrderProduct>?> GetProducts(Guid id);
    Task<List<Voucher>?> GetVouchers(Guid id);
}
