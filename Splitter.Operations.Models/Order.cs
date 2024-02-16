﻿using System.Runtime.InteropServices;
using Splitter.Operations.Constants;

namespace Splitter.Operations.Models;

public class Order
{
    public Guid Id { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
    public DateTime PaidAt { get; set; }
    public OrderStatus Status { get; private set; }

    public Guid EventTableId { get; set; }
    public virtual EventTable? EventTable { get; set; }
    public virtual List<Product>? Products { get; set; }
    public virtual List<Voucher>? Vouchers { get; set; }

    public static Order Create(Guid eventTableId) => new()
    {
        EventTableId = eventTableId,
        CreatedAt = DateTime.Now,
        Status = OrderStatus.Open
    };

    public bool IsClosed() => Status != OrderStatus.Closed;

    public bool IsPaid() => Status != OrderStatus.Paid;

    public bool IsOpen() => Status != OrderStatus.Open;

    public decimal SumAllProducts() => Products?.Sum(product => product.Price) ?? 0;
    public void CloseOrder()
    {
        Status = OrderStatus.Closed;
        ClosedAt = DateTime.Now;
    }

    public void OpenOrder()
    {
        Status = OrderStatus.Open;
        ClosedAt = DateTime.MinValue;
    }

    public void PaidOrder()
    {
        Status = OrderStatus.Paid;
        PaidAt = DateTime.Now;
    }

    public bool HasVouchers() => Vouchers switch
    {
        null => false,
        _ => Vouchers.Count > 0,
    };

    public decimal SummAllVouchers() => Vouchers?.Sum(voucher => voucher.Total) ?? 0;
}