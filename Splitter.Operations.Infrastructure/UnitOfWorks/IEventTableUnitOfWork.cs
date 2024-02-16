using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IEventTableUnitOfWork
{
    Task<Guid> AddProductToOrder(Guid orderId, Product product);
    Task<Order> AddTableOrder(Order order);
    Task<Voucher> AddVoucherToOrder(Guid id, Voucher voucher);
    Task<EventTable> CreateEventTableAsync(EventTable eventTable);
    Task<EventTable?> GetEventTable(Guid eventTableId);
    Task<Order?> GetOrder(Guid eventTableId);
    Task<Guid> UpdateOrder(Order order);
    
    Task<int> SaveChangesAsync();
}
