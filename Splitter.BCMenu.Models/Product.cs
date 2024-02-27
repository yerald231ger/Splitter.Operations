namespace Splitter.BCMenu.Models;

public class Product
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Descripcion { get; set; }
    public bool IsActive { get; set; } 

    public List<Image> Images { get; set; } = [];

    public List<Category> Categories { get; set; } = [];

    public void AddCategory(Category category){
        Categories.Add(category);
    }
}