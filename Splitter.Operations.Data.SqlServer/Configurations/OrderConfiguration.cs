using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders")
        .HasKey(t => t.Id);

        builder.HasMany(t => t.Products)
        .WithOne(p => p.Order)
        .HasForeignKey(p => p.OrderId);

        builder.HasMany(t => t.Vouchers)
        .WithOne(p => p.Order)
        .HasForeignKey(p => p.OrderId);
        
        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd();

        builder.Property(p => p.Total)
        .HasColumnType("decimal(18, 2)");
    }
}