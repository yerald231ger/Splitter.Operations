﻿using Microsoft.Extensions.Logging;
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
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.InvalidEventTableName, SptRejectCodes.InvalidEventTableName.GetDescription());

            var evenTTable = await evenTableUnitOfWork.CreateEventTableAsync(EventTable.Create(command.Name));
            return _sptInterface.CompleteCreate(command.CommandId, evenTTable);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating event table");
            return _sptInterface.Reject(command.CommandId, SptRejectCodes.RepositoryError);
        }
    }

    public async Task<SptResult> OrderProduct(CreateProductCommand command)
    {
        try
        {
            _logger.LogInformation("Ordering Product");

            var eventTable = await evenTableUnitOfWork.GetEventTable(command.EventTableId);
            var order = eventTable?.Order;

            if (eventTable is null)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.EventTableNotFound, SptRejectCodes.EventTableNotFound.GetDescription());

            if (string.IsNullOrWhiteSpace(command.ProductName))
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.InvalidProductName, SptRejectCodes.InvalidProductName.GetDescription());

            if (eventTable.HasOrder())
            {
                var product = Product.Create(command.ProductName, command.ProductPrice);
                order!.AddProduct(product);
            }
            else
            {
                order = Order.Create(command.EventTableId);
                var product = Product.Create(command.ProductName, command.ProductPrice);
                order.AddProduct(product);
                eventTable.AddOrder(order);
            }

            await evenTableUnitOfWork.UpdateTableEvent(eventTable);
            await evenTableUnitOfWork.SaveChangesAsync();
            return _sptInterface.CompleteCreate(command.CommandId, order);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while ordering product");
            return _sptInterface.Reject(command.CommandId, SptRejectCodes.RepositoryError, SptRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> CloseOrder(UpdateOrderCommand command)
    {
        try
        {
            _logger.LogInformation("Closing Order");
            var order = await evenTableUnitOfWork.GetOrder(command.EventTableId);

            if (order is null)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.OrderNotFound, SptRejectCodes.OrderNotFound.GetDescription());

            order.Total = order.SumAllProducts();
            order.CloseOrder();

            await evenTableUnitOfWork.UpdateOrder(order);

            return _sptInterface.CompleteUpdate(command.CommandId, order);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while closing order");
            return _sptInterface.Reject(command.CommandId, SptRejectCodes.RepositoryError, SptRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> PayTotalOrder(CreateVoucherCommand command)
    {
        try
        {
            _logger.LogInformation("Paying Order");
            var order = await evenTableUnitOfWork.GetOrder(command.EventTableId);

            if (order is null)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.OrderNotFound, SptRejectCodes.OrderNotFound.GetDescription());

            if (order.IsPaid())
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.OrderAlreadyPaid, SptRejectCodes.OrderAlreadyPaid.GetDescription());

            if (order.Total > command.Amount)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.InsufficientFunds, SptRejectCodes.InsufficientFunds.GetDescription());

            if (command.Tip is < 0 or > 100)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.InvalidTip, SptRejectCodes.InvalidTip.GetDescription());

            var voucher = Voucher.Create(command.Amount, command.Tip);
            order.AddVoucher(voucher);
            order.PaidOrder();

            await evenTableUnitOfWork.UpdateOrder(order);
            await evenTableUnitOfWork.SaveChangesAsync();
            return _sptInterface.CompleteCreate(command.CommandId, voucher);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while paying order");
            return _sptInterface.Reject(command.CommandId, SptRejectCodes.RepositoryError, SptRejectCodes.RepositoryError.GetDescription());
        }
    }

    public async Task<SptResult> PayPartialOrder(CreateVoucherCommand command)
    {
        try
        {
            _logger.LogInformation("Paying Partial Order");
            var order = await evenTableUnitOfWork.GetOrderWithVouchers(command.EventTableId);

            if (order is null)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.OrderNotFound, SptRejectCodes.OrderNotFound.GetDescription());

            if (order.IsPaid())
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.OrderAlreadyPaid, SptRejectCodes.OrderAlreadyPaid.GetDescription());  

            if (command.Tip is < 0 or > 100)
                return _sptInterface.Reject(command.CommandId, SptRejectCodes.InvalidTip, SptRejectCodes.InvalidTip.GetDescription());

            var voucher = Voucher.Create(command.Amount, command.Tip);
            order.AddVoucher(voucher);
            await evenTableUnitOfWork.UpdateOrder(order);
            await evenTableUnitOfWork.SaveChangesAsync();
            return _sptInterface.CompleteCreate(command.CommandId, voucher);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while paying partial order");
            return _sptInterface.Reject(command.CommandId, SptRejectCodes.RepositoryError, SptRejectCodes.RepositoryError.GetDescription());
        }
    }
}