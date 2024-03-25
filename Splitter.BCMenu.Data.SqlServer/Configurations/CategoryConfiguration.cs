using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedNever();
        
        builder.Ignore(p => p.Images);

        builder.HasData(categories);
    }

    private readonly List<Category> categories =
    [
        new Category
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("8d9d2154-54a5-4b09-b334-e1733ae3cfba"),
            Name = "Appetizers",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
        },
        new Category
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("84bdf70f-c194-4fdd-abac-2e8ecc248d3b"),
            Name = "Main Courses",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
        },
        new Category
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("571dd2a2-c73a-47f4-af8b-7fa689a82568"),
            Name = "Desserts",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
        },
        new Category
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.Parse("0a0faa3e-5e89-4fc9-8d78-0041049de8f6"),
            Name = "Burgers",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
        },
    ];
}
