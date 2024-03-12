using Splitter.Extensions;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Infrastructure;

public interface ICommensalityUnitOfWork : IUnitOfWork
{
    Task<int> AddProductToOrder(Guid orderId, OrderProduct product);
    Task<int> AddTableOrder(Order order);
    Task<int> AddVoucherToOrder(Guid id, Voucher voucher);
    Task<int> CreateCommensalityAsync(Models.Commensality commensality);
    Task<Models.Commensality?> GetCommensality(Guid commensalityId);
    Task<Order?> GetOrder(Guid commensalityId);
    Task<Guid> UpdateOrder(Order order);
    

    Task<Guid> UpdateCommensality(Models.Commensality commensality);
    Task<Order?> GetOrderWithVouchers(Guid commensalityId);
}
