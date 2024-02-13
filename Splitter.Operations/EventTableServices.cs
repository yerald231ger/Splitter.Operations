using Microsoft.Extensions.Logging;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations;

public class EventTableServices(
    ILogger<EventTableServices> logger,
    IEventTableUnitOfWork eventTableRepository)
{
    private readonly IEventTableUnitOfWork evenTableUnitOfWork = eventTableRepository;
    private readonly ILogger<EventTableServices> _logger = logger;

    public async Task<EventTable> CreateEvent(string name)
    {
        _logger.LogInformation("Creating Event Table");
        var evenTTableId = await evenTableUnitOfWork.CreateEventTableAsync(EventTable.Create(name));
        return evenTTableId;
    }

    public async Task<OrderTable> OrderProduct(Guid eventTableId, string productName, decimal productPrice)
    {
        _logger.LogInformation("Ordering Product");

        var eventTable = await evenTableUnitOfWork.GetEventTable(eventTableId)
        ?? throw new ArgumentException($"Event Table with id {eventTableId} not found");

        if (eventTable.HasOrderTable())
        {
            var product = Product.Create(productName, productPrice, eventTable.OrderTable!.Id);
            await evenTableUnitOfWork.AddProductToOrder(eventTable.OrderTable!.Id, product);
            return eventTable.OrderTable;
        }
        else
        {
            var orderTable = await evenTableUnitOfWork.AddTableOrder(OrderTable.Create());

            var product = Product.Create(productName, productPrice, orderTable.Id);
            await evenTableUnitOfWork.AddProductToOrder(orderTable.Id, product);
            return orderTable;
        }
    }

    public async Task<OrderTable> CloseOrder(Guid orderId)
    {
        _logger.LogInformation("Closing Order");
        var orderTable = await evenTableUnitOfWork.GetOrder(orderId)
        ?? throw new ArgumentException($"Order with id {orderId} not found");

        orderTable.Total = orderTable.SumAllProducts();
        orderTable.CloseOrder();

        await evenTableUnitOfWork.UpdateOrder(orderTable);

        return orderTable;
    }

    public async Task<Voucher> PayTotalOrder(Guid orderId, decimal amount, int tip)
    {
        _logger.LogInformation("Paying Order");
        var orderTable = await evenTableUnitOfWork.GetOrder(orderId)
        ?? throw new ArgumentException($"Order with id {orderId} not found");

        var voucher = await evenTableUnitOfWork.AddVoucherToOrder(orderTable.Id, Voucher.Create(amount, tip));

        if (orderTable.Total > amount)
        {
            throw new ArgumentException($"Amount {amount} is less than the total {orderTable.Total}");
        }

        orderTable.PaidOrder();

        await evenTableUnitOfWork.UpdateOrder(orderTable);

        return voucher;
    }

    public async Task<Voucher> PayPartialOrder(Guid orderId, decimal amount, int tip)
    {
        _logger.LogInformation("Paying Partial Order");
        var orderTable = await evenTableUnitOfWork.GetOrder(orderId)
        ?? throw new ArgumentException($"Order with id {orderId} not found");

        Voucher voucher;

        if (!orderTable.HasVouchers())
        {
            voucher = await evenTableUnitOfWork.AddVoucherToOrder(orderTable.Id, Voucher.Create(amount, tip));
            return voucher;
        }

        voucher = await evenTableUnitOfWork.AddVoucherToOrder(orderTable.Id, Voucher.Create(amount, tip));

        if (orderTable.Total < orderTable.SummAllVouchers())
            return voucher;

        orderTable.PaidOrder();
        await evenTableUnitOfWork.UpdateOrder(orderTable);

        return voucher;
    }

}