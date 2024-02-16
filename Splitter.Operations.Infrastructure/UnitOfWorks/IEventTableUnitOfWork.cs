using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IEventTableUnitOfWork
{
    Task<Guid> AddProductToOrder(Guid orderTableId, Product product);
    Task<OrderTable> AddTableOrder(OrderTable orderTable);
    Task<Voucher> AddVoucherToOrder(Guid id, Voucher voucher);
    Task<EventTable> CreateEventTableAsync(EventTable eventTable);
    Task<EventTable?> GetEventTable(Guid eventTableId);
    Task<OrderTable?> GetOrder(Guid eventTableId);
    Task<Guid> UpdateOrder(OrderTable orderTable);
    
    Task<int> SaveChangesAsync();
}
