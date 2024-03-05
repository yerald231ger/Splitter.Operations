namespace Splitter.BCMenu.Models;
public class Category
{
    public required Guid Id { get; set; }    
    public required Guid EstablishmentId { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; }

    public Guid? MenuId { get; set; }

    public Menu? Menu { get; set; }

    public List<Image> Images { get; set; } = [];

    public static Category Create(Guid id, Guid establishmentId, Guid guid, string name, bool isActive) => new()
    {
        Id = id,
        EstablishmentId = establishmentId,
        Name = name,
        IsActive = isActive
    };
}