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

        builder.HasMany(t => t.Images)
        .WithOne()
        .HasForeignKey(p => p.ObjectId);
        
        builder.Property(p => p.Price)
        .HasColumnType("decimal(18, 2)");
    }
}
