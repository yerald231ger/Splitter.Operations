using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedNever();

        builder.Property(p => p.Price)
        .HasColumnType("decimal(18, 2)");

        builder.Ignore(p => p.Images);

        builder.HasData(products);
    }

    private static readonly List<Product> products =
    [
        // Appetizers
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
            Name = "Caprese Salad",
            Description = "Fresh sliced tomatoes and mozzarella, topped with basil, olive oil, and balsamic glaze",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 7.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
            Name = "Garlic Bread",
            Description = "Crusty bread buttered with a savory garlic spread, toasted to perfection",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 4.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("30000000-0000-0000-0000-000000000000"),
            Name = "Bruschetta",
            Description = "Classic Italian appetizer with tomato, basil, and mozzarella on toasted bread",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 5.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("40000000-0000-0000-0000-000000000000"),
            Name = "Stuffed Mushrooms",
            Description = "Mushroom caps filled with a mixture of cheeses, garlic, and breadcrumbs, baked until golden",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 8.50m
        },

        // Main Courses
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("50000000-0000-0000-0000-000000000000"),
            Name = "Classic Cheeseburger",
            Description = "Juicy beef patty with cheddar cheese, lettuce, tomato, and our special sauce on a toasted bun",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 8.50m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("60000000-0000-0000-0000-000000000000"),
            Name = "Bacon Avocado Burger",
            Description = "Grilled beef patty topped with crispy bacon, avocado slices, and garlic aioli on a brioche bun",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 10.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("70000000-0000-0000-0000-000000000000"),
            Name = "Mushroom Swiss Burger",
            Description = "Beef patty with sautéed mushrooms, melted Swiss cheese, and Dijon mustard on a sesame seed bun",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 9.50m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("80000000-0000-0000-0000-000000000000"),
            Name = "Spicy Jalapeno Burger",
            Description = "Beef patty with jalapenos, pepper jack cheese, crispy onions, and spicy mayo on a spicy toasted bun",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 9.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("90000000-0000-0000-0000-000000000000"),
            Name = "Veggie Burger",
            Description = "Grilled plant-based patty with lettuce, tomato, cucumber, and yogurt sauce on a whole wheat bun",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 8.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("11000000-0000-0000-0000-000000000000"),
            Name = "Lasagna",
            Description = "Layered pasta with meat, cheese, and tomato sauce",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 12.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("12000000-0000-0000-0000-000000000000"),
            Name = "Caesar Salad",
            Description = "Classic Caesar salad with croutons and parmesan cheese",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 7.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("13000000-0000-0000-0000-000000000000"),
            Name = "Spaghetti Carbonara",
            Description = "Spaghetti with creamy egg sauce, pancetta, and black pepper",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 11.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("14000000-0000-0000-0000-000000000000"),
            Name = "Chicken Wings",
            Description = "Spicy glazed chicken wings with a side of blue cheese dip",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 9.00m
        },

        // Beverages
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("15000000-0000-0000-0000-000000000000"),
            Name = "Espresso",
            Description = "Strong and richly flavored concentrated coffee",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 2.50m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("16000000-0000-0000-0000-000000000000"),
            Name = "Cappuccino",
            Description = "A classic Italian coffee drink with espresso, hot milk, and steamed-milk foam",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 3.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("17000000-0000-0000-0000-000000000000"),
            Name = "Lemonade",
            Description = "Refreshing drink made from lemon juice, water, and sugar",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 2.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("18000000-0000-0000-0000-000000000000"),
            Name = "Iced Tea",
            Description = "Cold tea served with ice, and often with a slice of lemon",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 2.50m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("19000000-0000-0000-0000-000000000000"),
            Name = "Sparkling Water",
            Description = "Carbonated water served chilled, perfect as a palate cleanser or refreshing drink",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 1.50m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("2A000000-0000-0000-0000-000000000000"),
            Name = "Hot Chocolate",
            Description = "Rich chocolate drink made with milk, cocoa, and sugar, topped with whipped cream",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 3.00m
        },

        // Desserts
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("21000000-0000-0000-0000-000000000000"),
            Name = "Chocolate Mousse",
            Description = "Rich and airy chocolate mousse, made with high-quality dark chocolate and served with whipped cream",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 4.75m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("22000000-0000-0000-0000-000000000000"),
            Name = "Tiramisu",
            Description = "Coffee-flavored Italian dessert with mascarpone cheese",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 6.50m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("23000000-0000-0000-0000-000000000000"),
            Name = "Cheesecake",
            Description = "Creamy cheesecake on a graham cracker crust, served with a choice of strawberry, blueberry, or raspberry topping",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 6.00m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("24000000-0000-0000-0000-000000000000"),
            Name = "Fruit Sorbet",
            Description = "Refreshing sorbet made from pureed fruits and served in a natural fruit shell",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 3.50m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("25000000-0000-0000-0000-000000000000"),
            Name = "Lemon Meringue Pie",
            Description = "Tart lemon custard filling with a fluffy meringue topping, served on a crisp pastry base",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 5.25m
        },
        new Product
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("26000000-0000-0000-0000-000000000000"),
            Name = "Baklava",
            Description = "Rich, sweet pastry made of layers of filo filled with chopped nuts and sweetened with syrup or honey",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Price = 4.00m
        }
    ];
}
