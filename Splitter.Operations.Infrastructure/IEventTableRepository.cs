using Splitter.Operations.Models;

namespace Splitter.Operations.Infrastructure;

public interface IEventTableRepository
{
    int AddProductToOrder(Guid id, object product);
    OrderTable AddTableOrder(OrderTable orderTable);
    OrderTable AddVoucherToOrder(Guid id, Voucher voucher);
    EventTable CreateEventTable(EventTable eventTable);
    EventTable GetEventTable(Guid eventTableId);
    OrderTable GetOrder(Guid orderId);
    OrderTable UpdateOrder(OrderTable orderTable);
}
