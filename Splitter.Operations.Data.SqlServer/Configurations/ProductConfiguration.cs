using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd();

        builder.Property(p => p.Price)
        .HasColumnType("decimal(18, 2)");

        builder.HasMany(p => p.Tags)
        .WithMany(p => p.Products)
        .UsingEntity(t => t.ToTable("ProductTag"));

    }
}