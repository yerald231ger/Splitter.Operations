using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IOrderRepository : IRepository<Order, Guid>
{
    Task<List<Product>?> GetProducts(Guid id);
    Task<List<Voucher>?> GetVouchers(Guid id);
}
