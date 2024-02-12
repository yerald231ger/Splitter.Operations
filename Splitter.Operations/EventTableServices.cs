using Microsoft.Extensions.Logging;
using Splitter.Operations.Constants;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations;

public class EventTableServices(
    ILogger<EventTableServices> logger,
    IEventTableRepository eventTableRepository)
{
    private readonly IEventTableRepository _eventTableRepository = eventTableRepository;
    private readonly ILogger<EventTableServices> _logger = logger;

    public EventTable CreateEvent(string name)
    {
        _logger.LogInformation("Creating Event Table");
        var eventtable = _eventTableRepository.CreateEventTable(EventTable.Create(name));
        return eventtable;
    }

    public OrderTable OrderProduct(Guid eventTableId, string productName, decimal productPrice)
    {
        _logger.LogInformation("Ordering Product");

        var product = Product.Create(productName, productPrice);

        var eventTable = _eventTableRepository.GetEventTable(eventTableId)
        ?? throw new ArgumentException($"Event Table with id {eventTableId} not found");

        if (eventTable.HasOrderTable())
        {
            _eventTableRepository.AddProductToOrder(eventTable.OrderTable!.Id, product);
            return eventTable.OrderTable;
        }
        else
        {
            var orderTable = _eventTableRepository.AddTableOrder(OrderTable.Create());
            _eventTableRepository.AddProductToOrder(orderTable.Id, product);
            return orderTable;
        }
    }

    public OrderTable CloseOrder(Guid orderId)
    {
        _logger.LogInformation("Closing Order");
        var orderTable = _eventTableRepository.GetOrder(orderId)
        ?? throw new ArgumentException($"Order with id {orderId} not found");

        orderTable.Total = orderTable.Products?.Sum(p => p.Price) ?? 0;
        orderTable.Status = OrderTableStatus.Closed;
        orderTable.ClosedAt = DateTime.Now;

        orderTable = _eventTableRepository.UpdateOrder(orderTable);

        return orderTable;
    }

    public OrderTable PayOrder(Guid orderId, decimal amount, int tip)
    {
        _logger.LogInformation("Paying Order");
        var orderTable = _eventTableRepository.GetOrder(orderId)
        ?? throw new ArgumentException($"Order with id {orderId} not found");

        if (orderTable.Total > amount)
        {
            throw new ArgumentException($"Amount {amount} is less than the total {orderTable.Total}");
        }

        orderTable = _eventTableRepository.AddVoucherToOrder(orderTable.Id, Voucher.Create(amount, tip));

        orderTable.Status = OrderTableStatus.Paid;
        orderTable.PaidAt = DateTime.Now;

        orderTable = _eventTableRepository.UpdateOrder(orderTable);

        return orderTable;
    }

    public OrderTable PayPartialOrder(Guid orderId, decimal amount, int tip)
    {
        _logger.LogInformation("Paying Partial Order");
        var orderTable = _eventTableRepository.GetOrder(orderId)
        ?? throw new ArgumentException($"Order with id {orderId} not found");

        if (!orderTable.HasVouchers())
        {
            orderTable = _eventTableRepository.AddVoucherToOrder(orderTable.Id, Voucher.Create(amount, tip));
            return orderTable;
        }

        if (orderTable.Total >= orderTable.Vouchers!.Sum(v => v.Amount) + amount)
        {
            orderTable.Status = OrderTableStatus.Closed;
            orderTable.PaidAt = DateTime.Now;
            orderTable = _eventTableRepository.UpdateOrder(orderTable);
        }

        orderTable = _eventTableRepository.AddVoucherToOrder(orderTable.Id, Voucher.Create(amount, tip));

        return orderTable;
    }

}
