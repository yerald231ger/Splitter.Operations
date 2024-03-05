using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        
        builder.HasMany(t => t.Images)
        .WithOne()
        .HasForeignKey(p => p.ObjectId);

        builder.HasMany(t => t.MenuLayouts)
        .WithOne(p => p.Menu)
        .HasForeignKey(p => p.MenuId);
    }
}