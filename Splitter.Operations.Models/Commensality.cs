namespace Splitter.Operations.Models;

public class Commensality
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime FinishedAt { get; set; }
    public Order? Order { get; set; }

    public static Commensality Create(Guid id, string name) => new()
    {
        Id = id,
        Name = name,
        CreatedAt = DateTime.Now,
        FinishedAt = DateTime.MaxValue
    };

    public void AddOrder(Order order) => Order = order;

    public bool HasOrder() => Order != null;
}
