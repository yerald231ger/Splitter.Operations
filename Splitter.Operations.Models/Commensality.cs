namespace Splitter.Operations.Models;

public class Commensality
{
    public Guid Id { get; set; } 
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime FinishedAt { get; set; } 
    public Order? Order { get; set; }

    public static Commensality Create(string name) => string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException($"cannot be null or empty", nameof(name))
            : new Commensality
            {
                Name = name,
                CreatedAt = DateTime.Now,
                FinishedAt = DateTime.MaxValue
            };

    public void AddOrder(Order order) => Order = order;

    public bool HasOrder() => Order != null;
}
