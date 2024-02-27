using Splitter.Extensions;
using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface ICommensalityUnitOfWork : IUnitOfWork
{
    Task<int> AddProductToOrder(Guid orderId, OrderProduct product);
    Task<int> AddTableOrder(Order order);
    Task<int> AddVoucherToOrder(Guid id, Voucher voucher);
    Task<int> CreateCommensalityAsync(Commensality commensality);
    Task<Commensality?> GetCommensality(Guid commensalityId);
    Task<Order?> GetOrder(Guid commensalityId);
    Task<Guid> UpdateOrder(Order order);
    

    Task<Guid> UpdateCommensality(Commensality commensality);
    Task<Order?> GetOrderWithVouchers(Guid commensalityId);
}
