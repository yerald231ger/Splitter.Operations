namespace Splitter.Operations.Models;

public class Voucher
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public decimal Total { get; set; }
    public Tip Tip { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public static Voucher Create(decimal amount, Tip tip)
    {
        if (amount <= 0)
            throw new ArgumentException("cannot be less than or equal to 0", nameof(amount));

        return new Voucher
        {
            Amount = amount,
            Tip = tip,
            CreatedAt = DateTime.Now,
            Total = amount + tip
        };
    }
}
