using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IOrderRepository : IRepository<Order, Guid>
{
    Task<List<Order>> Filter(DateTime? from, DateTime? to, bool withProducts, bool withVouchers);
}
