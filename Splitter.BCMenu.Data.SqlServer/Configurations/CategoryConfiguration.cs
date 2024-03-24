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
        
        builder.HasMany(t => t.Images)
        .WithOne()
        .HasForeignKey(p => p.ObjectId);

        builder.HasData(categories);
    }

    private readonly List<Category> categories =
    [
        new Category
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.NewGuid(),
            Name = "Appetizers",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
        },
        new Category
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.NewGuid(),
            Name = "Main Courses",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
        },
        new Category
        {
            EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
            Id = Guid.NewGuid(),
            Name = "Desserts",
            MenuId = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
        },
    ];
}
