namespace Splitter.Operations.Models;

public class OrderProduct
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order? Order { get; set; }

    public static OrderProduct Create(string name, decimal price) => new()
    {
        Name = name,
        Price = price
    };
}
