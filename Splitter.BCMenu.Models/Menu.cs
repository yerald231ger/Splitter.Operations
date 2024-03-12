using System.Text.Json;

namespace Splitter.BCMenu.Models;

public class Menu
{
    public required Guid Id { get; set; }
    public required Guid EstablishmentId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<ScaffoldCategory<ScaffoldProduct>> Layout { get; set; } = [];
    public List<MenuLayout> MenuLayouts { get; set; } = [];
    public List<Product> Products { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
    public List<Image> Images { get; set; } = [];

    public static Menu Create(Guid id, Guid establishmentId, string name, bool isActive) => new()
    {
        Id = id,
        EstablishmentId = establishmentId,
        Name = name,
        IsActive = isActive,
    };

    public void AddOrCreateProduct(Guid productId, Guid establishmentId, string productName, decimal productPrice)
    {
        var product = CreateProduct(productId, establishmentId, productName, productPrice);
        Products.Add(product);
    }

    public void AddLayout(MenuLayout menuLayout)
    {
        MenuLayouts.Add(menuLayout);
    }

    public void BuildLayoutToDisplay()
    {
        var lastCreated = MenuLayouts.Last();

        if (lastCreated != null && lastCreated.Layout != null)
        {
            var scaffolds = JsonSerializer.Deserialize<List<ScaffoldCategory<Guid>>>(lastCreated.Layout);
            var layoutBuilded = new List<ScaffoldCategory<ScaffoldProduct>>();
            if (scaffolds != null)
                AddProductsToCategory(scaffolds, ref layoutBuilded);
            Layout = layoutBuilded;
        }
    }

    private void AddProductsToCategory(List<ScaffoldCategory<Guid>> categories, ref List<ScaffoldCategory<ScaffoldProduct>> scaffoldToBuild)
    {

        foreach (var category in categories)
        {
            var categoryToBuild = new ScaffoldCategory<ScaffoldProduct>
            {
                Title = category.Title
            };

            if (category.Products != null)
                foreach (var product in category.Products)
                {
                    var productFound = Products.FirstOrDefault(p => p.Id == product);
                    if (productFound != null)
                    {
                        var productToBuild = new ScaffoldProduct
                        {
                            Id = productFound.Id,
                            Name = productFound.Name,
                            Price = productFound.Price,
                            Description = productFound.Description
                        };
                        categoryToBuild.Products.Add(productToBuild);
                    }
                }

            scaffoldToBuild.Add(categoryToBuild);
            if (category.Categories.Count > 0)
            {
                var inner = new List<ScaffoldCategory<ScaffoldProduct>>();
                AddProductsToCategory(category.Categories, ref inner);
            }
        }
    }

    public void AddOrCreateCategory(Guid categoryId, Guid establishmentId, string name)
    {
        var category = CreateCategory(categoryId, establishmentId, name);
        Categories.Add(category);
    }

    public Product? GetFirstProduct(Guid productId) => Products.FirstOrDefault(p => p.Id == productId);

    public static Category CreateCategory(Guid categoryId, Guid establishmentId, string name) => new()
    {
        Id = categoryId,
        EstablishmentId = establishmentId,
        Name = name,
        IsActive = true,
    };

    public static Product CreateProduct(Guid guid, Guid establishmentId, string name, decimal price)
    {
        return new Product
        {
            Id = guid,
            EstablishmentId = establishmentId,
            Name = name,
            Price = price,
            Description = string.Empty,
            IsActive = true,
        };
    }

    public bool HasProduct(Guid productId) => Products.Any(p => p.Id == productId);
    public bool HasCategory(Guid categoryId) => Categories.Any(c => c.Id == categoryId);

    public void UpdateProduct(Guid productId, string productName, decimal productPrice, string productDescription)
    {
        if (!HasProduct(productId))
            throw new Exception("Product not found");
        else
        {
            var product = Products.First(p => p.Id == productId);
            product.Name = productName;
            product.Price = productPrice;
            product.Description = productDescription;
        }
    }

    public void UpdateCategory(Guid categoryId, string categoryName)
    {
        if (!HasCategory(categoryId))
            throw new Exception("Category not found");
        else
        {
            var category = Categories.First(c => c.Id == categoryId);
            category.Name = categoryName;
        }
    }

    public void ModifyCategoryName(Guid categoryId, string categoryName)
    {
        var category = Categories.FirstOrDefault(c => c.Id == categoryId);
        if (category != null)
        {
            category.Name = categoryName;
        }
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }

    public void RemoveCategory(Category category)
    {
        Categories.Remove(category);
    }

    public static MenuLayout CreateLayout(Guid menuId, Guid layoutId, JsonDocument layout, string name)
    {
        return new MenuLayout
        {
            Id = layoutId,
            MenuId = menuId,
            Layout = layout,
            Name = name,
        };
    }
}