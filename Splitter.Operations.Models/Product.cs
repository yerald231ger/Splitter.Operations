namespace Splitter.Operations.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public List<Tag>? Tags { get; set; }

    public static object Create(string name, decimal price)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("cannot be null or empty", nameof(name));
        }

        return new Product
        {
            Name = name,
            Price = price,
            Tags = []
        };
    }
}
