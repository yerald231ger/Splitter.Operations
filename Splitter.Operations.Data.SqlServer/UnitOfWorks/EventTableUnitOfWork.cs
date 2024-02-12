using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class EventTableUnitOfWork : IEventTableUnitOfWork
{   
    
    public int AddProductToOrder(Guid id, object product)
    {
        throw new NotImplementedException();
    }

    public OrderTable AddTableOrder(OrderTable orderTable)
    {
        throw new NotImplementedException();
    }

    public OrderTable AddVoucherToOrder(Guid id, Voucher voucher)
    {
        throw new NotImplementedException();
    }

    public EventTable CreateEventTable(EventTable eventTable)
    {
        throw new NotImplementedException();
    }

    public EventTable GetEventTable(Guid eventTableId)
    {
        throw new NotImplementedException();
    }

    public OrderTable GetOrder(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public OrderTable UpdateOrder(OrderTable orderTable)
    {
        throw new NotImplementedException();
    }
}
