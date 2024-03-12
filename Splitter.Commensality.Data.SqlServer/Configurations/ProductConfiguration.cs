using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

public class ProductConfiguration : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable("OrderProducts")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd();

        builder.Property(p => p.Price)
        .HasColumnType("decimal(18, 2)");

    }
}