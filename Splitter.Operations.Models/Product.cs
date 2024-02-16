namespace Splitter.Operations.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public List<Tag>? Tags { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order? Order { get; set; }

    public static Product Create(string name, decimal price) => new()
    {
        Name = name,
        Price = price,
        Tags = []
    };


}
