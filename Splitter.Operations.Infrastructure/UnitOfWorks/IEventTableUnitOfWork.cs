using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IEventTableUnitOfWork
{
    Task<Guid> AddProductToOrder(Guid orderTableId, Product product);
    Task<Order> AddTableOrder(Order orderTable);
    Task<Voucher> AddVoucherToOrder(Guid id, Voucher voucher);
    Task<EventTable> CreateEventTableAsync(EventTable eventTable);
    Task<EventTable?> GetEventTable(Guid eventTableId);
    Task<Order?> GetOrder(Guid eventTableId);
    Task<Guid> UpdateOrder(Order orderTable);
    
    Task<int> SaveChangesAsync();
}
