using Microsoft.Extensions.Logging;
using Splitter.Operations.Constants;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations;

public class EventTableServices(
    ILogger<EventTableServices> logger,
    IEventTableUnitOfWork eventTableRepository,
    ISptInterface sptInterface)
{
    private readonly IEventTableUnitOfWork evenTableUnitOfWork = eventTableRepository;
    private readonly ILogger<EventTableServices> _logger = logger;
    private readonly ISptInterface _sptInterface = sptInterface;

    public async Task<SptResult> CreateEvent(CreateEventTableCommand command)
    {
        try
        {
            _logger.LogInformation("Creating Event Table");
            if (string.IsNullOrWhiteSpace(command.Name))
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.InvalidEventTableName);

            var evenTTable = await evenTableUnitOfWork.CreateEventTableAsync(EventTable.Create(command.Name));
            return _sptInterface.CompleteCreate(command.CommandId, evenTTable);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating event table");
            return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.RepositoryError);
        }
    }

    public async Task<SptResult> OrderProduct(CreateProductCommand command)
    {
        try
        {
            _logger.LogInformation("Ordering Product");

            var eventTable = await evenTableUnitOfWork.GetEventTable(command.EventTableId);

            if (eventTable is null)
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.EventTableNotFound);

            if (string.IsNullOrWhiteSpace(command.ProductName))
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.InvalidProductName);

            if (eventTable.HasOrderTable())
            {
                var product = Product.Create(command.ProductName, command.ProductPrice, eventTable.Order!.Id);
                await evenTableUnitOfWork.AddProductToOrder(eventTable.Order!.Id, product);
                eventTable.Order!.Total += command.ProductPrice;
                await evenTableUnitOfWork.UpdateOrder(eventTable.Order!);
                return _sptInterface.CompleteCreate(command.CommandId, eventTable.Order);
            }
            else
            {
                var order = Order.Create(command.EventTableId);
                order.Total = command.ProductPrice;
                order = await evenTableUnitOfWork.AddTableOrder(order);

                var product = Product.Create(command.ProductName, command.ProductPrice, order.Id);
                await evenTableUnitOfWork.AddProductToOrder(order.Id, product);
                return _sptInterface.CompleteCreate(command.CommandId, order);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while ordering product");
            return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.RepositoryError);
        }
    }

    public async Task<SptResult> CloseOrder(UpdateOrderCommand command)
    {
        try
        {
            _logger.LogInformation("Closing Order");
            var order = await evenTableUnitOfWork.GetOrder(command.EventTableId);

            if (order is null)
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.OrderNotFound);

            order.Total = order.SumAllProducts();
            order.CloseOrder();

            await evenTableUnitOfWork.UpdateOrder(order);

            return _sptInterface.CompleteUpdate(command.CommandId, order);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while closing order");
            return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.RepositoryError);
        }
    }

    public async Task<SptResult> PayTotalOrder(CreateVoucherCommand command)
    {
        try
        {
            _logger.LogInformation("Paying Order");
            var order = await evenTableUnitOfWork.GetOrder(command.EventTableId);

            if (order is null)
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.OrderNotFound);

            if (order.IsPaid())
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.OrderAlreadyPaid);

            if (order.Total > command.Amount)
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.InsufficientFunds);

            if (command.Tip is < 0 or > 100)
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.InvalidTip);

            var voucher = await evenTableUnitOfWork.AddVoucherToOrder(order.Id, Voucher.Create(command.Amount, command.Tip));

            order.PaidOrder();

            await evenTableUnitOfWork.UpdateOrder(order);

            return _sptInterface.CompleteCreate(command.CommandId, voucher);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while paying order");
            return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.RepositoryError);
        }
    }

    public async Task<SptResult> PayPartialOrder(CreateVoucherCommand command)
    {
        try
        {
            _logger.LogInformation("Paying Partial Order");
            var order = await evenTableUnitOfWork.GetOrder(command.EventTableId);

            if (order is null)
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.OrderNotFound);

            if (order.IsPaid())
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.OrderAlreadyPaid);

            if (command.Tip is < 0 or > 100)
                return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.InvalidTip);

            Voucher voucher;

            if (!order.HasVouchers())
            {
                voucher = await evenTableUnitOfWork.AddVoucherToOrder(order.Id, Voucher.Create(command.Amount, command.Tip));
                return _sptInterface.CompleteCreate(command.CommandId, voucher);
            }

            voucher = await evenTableUnitOfWork.AddVoucherToOrder(order.Id, Voucher.Create(command.Amount, command.Tip));

            if (order.Total < order.SummAllVouchers())
                return _sptInterface.CompleteCreate(command.CommandId, voucher);

            order.PaidOrder();
            await evenTableUnitOfWork.UpdateOrder(order);

            return _sptInterface.CompleteCreate(command.CommandId, voucher);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while paying partial order");
            return _sptInterface.Reject(command.CommandId, SplitterRejectionCodes.RepositoryError);
        }
    }
}