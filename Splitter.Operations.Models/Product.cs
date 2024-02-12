namespace Splitter.Operations.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public List<Tag>? Tags { get; set; }

    public static Product Create(string name, decimal price) => string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("cannot be null or empty", nameof(name))
            : new Product
            {
                Name = name,
                Price = price,
                Tags = []
            };
}
