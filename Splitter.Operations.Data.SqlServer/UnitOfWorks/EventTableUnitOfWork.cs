using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class EventTableUnitOfWork(
    DbContext context,
    IEventTableRepository eventTableRepository,
    IOrderTableRepository orderTableRepository,
    IProductRepository productRepository,
    IVoucherRepository voucherRepository) : IEventTableUnitOfWork
{
    private readonly IEventTableRepository _eventTableRepository = eventTableRepository;
    private readonly IOrderTableRepository _orderTableRepository = orderTableRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IVoucherRepository _voucherRepository = voucherRepository;

    private readonly DbContext _context = context;

    public async Task<EventTable> CreateEventTableAsync(EventTable eventTable)
    {
        eventTable = await _eventTableRepository.AddAsync(eventTable);
        return eventTable;
    }

    public async Task<Guid> AddProductToOrder(Guid orderTableId, Product product)
    {
        product.OrderTableId = orderTableId;
        product = await _productRepository.AddAsync(product);
        return product.Id;
    }

    public Task<OrderTable> AddTableOrder(OrderTable orderTable)
    {
        return _orderTableRepository.AddAsync(orderTable);
    }

    public Task<Voucher> AddVoucherToOrder(Guid id, Voucher voucher)
    {
        voucher.OrderTableId = id;
        return _voucherRepository.AddAsync(voucher);
    }


    public Task<EventTable?> GetEventTable(Guid eventTableId)
    {
        return _eventTableRepository.GetEventTableWithOrder(eventTableId);
    }

    public Task<OrderTable?> GetOrder(Guid orderId)
    {
        return _orderTableRepository.GetByIdAsync(orderId);
    }

    public Task<Guid> UpdateOrder(OrderTable orderTable)
    {
        _orderTableRepository.UpdateAsync(orderTable);
        return Task.FromResult(orderTable.Id);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
