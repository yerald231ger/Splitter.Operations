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

    public async Task<Order> AddTableOrder(Order order)
    {
        return await _orderRepository.AddAsync(order);
    }

    public async Task<Voucher> AddVoucherToOrder(Guid id, Voucher voucher)
    {
        voucher.OrderId = id;
        return await _voucherRepository.AddAsync(voucher);
    }


    public async Task<EventTable?> GetEventTable(Guid eventTableId)
    {
        return await _eventTableRepository.GetEventTableWithOrder(eventTableId);
    }

    public async Task<Order?> GetOrder(Guid eventTableId)
    {
        return await _context.Orders.FirstOrDefaultAsync(o => o.EventTableId == eventTableId);
    }

    public async Task<Guid> UpdateOrder(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        return await Task.FromResult(order.Id);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<Guid> UpdateTableEvent(EventTable eventTable)
    {
        _context.Entry(eventTable).State = EntityState.Modified;
        return await Task.FromResult(eventTable.Id);
    }

    public async Task<Order?> GetOrderWithVouchers(Guid eventTableId)
    {
        return await _context.Orders
            .Include(o => o.Vouchers)
            .FirstOrDefaultAsync(o => o.EventTableId == eventTableId);
    }
}
