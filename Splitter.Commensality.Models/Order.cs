using System.Linq.Expressions;
using Splitter.Commensality.Constants;

namespace Splitter.Commensality.Models;

public class Order
{
    public Guid Id { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
    public DateTime PaidAt { get; set; }
    public OrderStatus Status { get; private set; }

    public Guid CommensalityId { get; set; }
    public virtual Commensality? Commensality { get; set; }
    public virtual List<OrderProduct>? Products { get; set; } = [];
    public virtual List<Voucher>? Vouchers { get; set; } = [];

    public static Expression<Func<Order, bool>> FilterFromTo(DateTime from, DateTime to)
         => order => order.CreatedAt >= from && order.CreatedAt <= to;

    public static Order Create(Guid commensalityId) => new()
    {
        CommensalityId = commensalityId,
        CreatedAt = DateTime.Now,
        Status = OrderStatus.Open
    };

    public bool IsClosed() => Status == OrderStatus.Closed;

    public bool IsPaid() => Status == OrderStatus.Paid;

    public bool IsOpen() => Status == OrderStatus.Open;

    public void SumPrice(decimal price) => Total += price;

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

    public void AddProduct(OrderProduct product)
    {
        SumPrice(product.Price);
        Products!.Add(product);
    }
    
    public void RemoveProduct(OrderProduct product)
    {
        SumPrice(-product.Price);
        Products!.Remove(product);
    }

    public decimal SummAllVouchers() => Vouchers?.Sum(voucher => voucher.Total) ?? 0;

    public void AddVoucher(Voucher voucher)
    {
        TotalPaid += voucher.Amount;
        if (TotalPaid >= Total)
            PaidOrder();
        Vouchers!.Add(voucher);
    }
}
