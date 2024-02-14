namespace Splitter.Operations.Models;

public class Tag
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public virtual List<Product>? Products { get; set; }
}
