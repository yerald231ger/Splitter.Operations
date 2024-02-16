namespace Splitter.Operations.Models;

public class EventTable
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime FinishedAt { get; set; }
    public Order? Order { get; set; }

    public static EventTable Create(string name) => string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException($"cannot be null or empty", nameof(name))
            : new EventTable
            {
                Name = name,
                CreatedAt = DateTime.Now,
                FinishedAt = DateTime.MaxValue
            };

    public bool HasOrder() => Order != null;
}
