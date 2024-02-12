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
    public OrderTableStatus Status { get; set; }

    public static OrderTable Create()
    {
        return new OrderTable();
    }

    public bool IsClosed()
    {
        return Status != OrderTableStatus.Closed;
    }

    public bool IsPaid()
    {
        return Status != OrderTableStatus.Paid;
    }

    public bool HasVouchers()
    {
        if (Vouchers == null)
        {
            return false;
        }
        return Vouchers.Count > 0;
    }
}
