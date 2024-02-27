namespace Splitter.BCMenu.Models;

public class Menu {
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Version { get; set; }
    public MenuLayout? MenuLayout { get; set; }
    public bool IsActive { get; set; }
    public List<Product> Products { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
    
    public void AddProduct(Product product){
        Products.Add(product);
    }

    public static void AsignCategoryToProduct(Category category, Product product){
        product.AddCategory(category);
    }

    public static Category CreateCategory(string name){
        return Category.CreateCategory(name, true);
    }

    public static Product CreateProduct(Guid guid, string name, decimal price){
        return new Product{
            Id = guid,
            Name = name,
            Price = price,
            Descripcion = string.Empty,
            IsActive = true,
        };
    }

    public void RemoveProduct(Product product){
        Products.Remove(product);
    }

    public void RemoveCategory(Category category){
        Categories.Remove(category);
    }

}