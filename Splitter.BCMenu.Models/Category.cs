namespace Splitter.BCMenu.Models;
public class Category
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; }   

    public static Category CreateCategory(string name, bool isActive){
        return new Category{
            Name = name,
            IsActive = isActive
        };
    }
}