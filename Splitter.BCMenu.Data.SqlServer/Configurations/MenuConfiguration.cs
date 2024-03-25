using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedNever();

        builder.HasMany(t => t.Products)
        .WithOne(p => p.Menu)
        .HasForeignKey(p => p.MenuId);

        builder.HasMany(t => t.Categories)
        .WithOne(p => p.Menu)
        .HasForeignKey(p => p.MenuId);

        builder.HasMany(t => t.MenuLayouts)
        .WithOne(p => p.Menu)
        .HasForeignKey(p => p.MenuId);
        
        builder.Ignore(p => p.Images);

        builder.Ignore(p => p.Layout);

        builder.HasData([
            new Menu
            {
                EstablishmentId = Guid.Parse("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                Id = Guid.Parse("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                Name = "Main Menu"
            }
        ]);
    }
}