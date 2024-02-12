namespace Splitter.Operations.Models;

public class EventTable
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime FinishedAt { get; set; }
    public  OrderTable? OrderTable { get; set; }

    public static EventTable Create(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"cannot be null or empty", nameof(name));
        }

        return new EventTable
        {
            Name = name,
            CreatedAt = DateTime.Now,
            FinishedAt = DateTime.MaxValue
        };
    }    

    public bool HasOrderTable()
    {
        return OrderTable != null;
    }
}
