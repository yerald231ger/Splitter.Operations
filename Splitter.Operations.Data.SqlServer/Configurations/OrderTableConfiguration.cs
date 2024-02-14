using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class OrderTableConfiguration : IEntityTypeConfiguration<OrderTable>
{
    public void Configure(EntityTypeBuilder<OrderTable> builder)
    {
        builder.ToTable("OrderTables")
        .HasKey(t => t.Id);

        builder.HasMany(t => t.Products)
        .WithOne(p => p.OrderTable)
        .HasForeignKey(p => p.OrderTableId);

        builder.HasMany(t => t.Vouchers)
        .WithOne(p => p.OrderTable)
        .HasForeignKey(p => p.OrderTableId);
        
        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd();

        builder.Property(p => p.Total)
        .HasColumnType("decimal(18, 2)");
    }
}