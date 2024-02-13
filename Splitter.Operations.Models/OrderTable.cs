using System.Runtime.InteropServices;
using Splitter.Operations.Constants;

namespace Splitter.Operations.Models;

public class OrderTable
{
    public Guid Id { get; set; }
    public decimal Total { get; set; }
    public List<Product>? Products { get; set; }
    public List<Voucher>? Vouchers { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
    public DateTime PaidAt { get; set; }
    public OrderTableStatus Status { get; private set; }

    public static OrderTable Create() => new();

    public bool IsClosed() => Status != OrderTableStatus.Closed;

    public bool IsPaid() => Status != OrderTableStatus.Paid;

    public bool IsOpen() => Status != OrderTableStatus.Open;

    public decimal SumAllProducts() => Products?.Sum(product => product.Price) ?? 0;
    public void CloseOrder()
    {
        Status = OrderTableStatus.Closed;
        ClosedAt = DateTime.Now;
    }

    public void OpenOrder()
    {
        Status = OrderTableStatus.Open;
        ClosedAt = DateTime.MinValue;
    }

    public void PaidOrder()
    {
        Status = OrderTableStatus.Paid;
        PaidAt = DateTime.Now;
    }

    public bool HasVouchers() => Vouchers switch
    {
        null => false,
        _ => Vouchers.Count > 0,
    };

    public decimal SummAllVouchers() => Vouchers?.Sum(voucher => voucher.Total) ?? 0;
}
