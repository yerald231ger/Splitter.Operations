﻿using Microsoft.EntityFrameworkCore;
using Splitter.Commensality.Infrastructure;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

public class CommensalityUnitOfWork(
    SplitterDbContext context,
    ICommensalityRepository CommensalityRepository,
    IOrderRepository orderRepository,
    IProductRepository productRepository,
    IVoucherRepository voucherRepository) : ICommensalityUnitOfWork
{
    private readonly ICommensalityRepository _CommensalityRepository = CommensalityRepository;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IVoucherRepository _voucherRepository = voucherRepository;

    private readonly SplitterDbContext _context = context;

    public async Task<int> CreateCommensalityAsync(Models.Commensality commensality)
    {
        var result = await _CommensalityRepository.AddAsync(commensality);
        return result;
    }

    public async Task<int> AddProductToOrder(Guid orderId, OrderProduct product)
    {
        product.OrderId = orderId;
        var result = await _productRepository.AddAsync(product);
        return result;
    }

    public async Task<int> AddTableOrder(Order order)
    {
        return await _orderRepository.AddAsync(order);
    }

    public async Task<int> AddVoucherToOrder(Guid id, Voucher voucher)
    {
        voucher.OrderId = id;
        return await _voucherRepository.AddAsync(voucher);
    }


    public async Task<Models.Commensality?> GetCommensality(Guid commensalityId)
    {
        return await _CommensalityRepository.GetCommensalityWithOrder(commensalityId);
    }

    public async Task<Order?> GetOrder(Guid commensalityId)
    {
        return await _context.Orders.FirstOrDefaultAsync(o => o.CommensalityId == commensalityId);
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

    public async Task<Guid> UpdateCommensality(Models.Commensality commensality)
    {
        _context.Entry(commensality).State = EntityState.Modified;
        return await Task.FromResult(commensality.Id);
    }

    public async Task<Order?> GetOrderWithVouchers(Guid commensalityId)
    {
        return await _context.Orders
            .Include(o => o.Vouchers)
            .FirstOrDefaultAsync(o => o.CommensalityId == commensalityId);
    }
}