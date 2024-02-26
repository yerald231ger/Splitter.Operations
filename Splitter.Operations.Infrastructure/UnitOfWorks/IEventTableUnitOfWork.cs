using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface ICommensalityUnitOfWork
{
    Task<Guid> AddProductToOrder(Guid orderId, OrderProduct product);
    Task<Order> AddTableOrder(Order order);
    Task<Voucher> AddVoucherToOrder(Guid id, Voucher voucher);
    Task<Commensality> CreateCommensalityAsync(Commensality commensality);
    Task<Commensality?> GetCommensality(Guid commensalityId);
    Task<Order?> GetOrder(Guid commensalityId);
    Task<Guid> UpdateOrder(Order order);
    
    Task<int> SaveChangesAsync();
    Task<Guid> UpdateCommensality(Commensality commensality);
    Task<Order?> GetOrderWithVouchers(Guid commensalityId);
}
