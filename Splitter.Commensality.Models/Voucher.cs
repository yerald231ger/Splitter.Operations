namespace Splitter.Commensality.Models;

public class Voucher
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public decimal Total { get; set; }
    public Tip Tip { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public static Voucher Create(Guid id, decimal amount, Tip tip) => new()
    {
        Id = id,
        Amount = amount,
        Tip = tip,
        CreatedAt = DateTime.Now,
        Total = amount + tip
    };
}
