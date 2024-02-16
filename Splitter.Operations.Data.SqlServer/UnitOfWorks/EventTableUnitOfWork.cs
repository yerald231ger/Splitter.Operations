using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Infrastructure;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class EventTableUnitOfWork(
    SplitterDbContext context,
    IEventTableRepository eventTableRepository,
    IOrderRepository orderRepository,
    IProductRepository productRepository,
    IVoucherRepository voucherRepository) : IEventTableUnitOfWork
{
    private readonly IEventTableRepository _eventTableRepository = eventTableRepository;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IVoucherRepository _voucherRepository = voucherRepository;

    private readonly SplitterDbContext _context = context;

    public async Task<EventTable> CreateEventTableAsync(EventTable eventTable)
    {
        eventTable = await _eventTableRepository.AddAsync(eventTable);
        return eventTable;
    }

    public async Task<Guid> AddProductToOrder(Guid orderId, Product product)
    {
        product.OrderId = orderId;
        product = await _productRepository.AddAsync(product);
        return product.Id;
    }

    public Task<Order> AddTableOrder(Order order)
    {
        return _orderRepository.AddAsync(order);
    }

    public Task<Voucher> AddVoucherToOrder(Guid id, Voucher voucher)
    {
        voucher.OrderId = id;
        return _voucherRepository.AddAsync(voucher);
    }


    public Task<EventTable?> GetEventTable(Guid eventTableId)
    {
        return _eventTableRepository.GetEventTableWithOrder(eventTableId);
    }

    public Task<Order?> GetOrder(Guid eventTableId)
    {
        var order = _context.Orders.ToList();
        return _context.Orders.FirstOrDefaultAsync(o => o.EventTableId == eventTableId);
    }

    public Task<Guid> UpdateOrder(Order order)
    {
        _orderRepository.UpdateAsync(order);
        return Task.FromResult(order.Id);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
