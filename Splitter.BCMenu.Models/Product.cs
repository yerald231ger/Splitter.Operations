namespace Splitter.BCMenu.Models;

public class Product
{
    public required Guid Id { get; set; }
    public required Guid EstablishmentId { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } 
    public Guid? MenuId { get; set; }
    public List<Image> Images { get; set; } = [];
    public Menu? Menu { get; set; }
}