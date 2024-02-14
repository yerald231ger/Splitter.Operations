using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;


public class EventTableConfiguration : IEntityTypeConfiguration<EventTable>
{
    public void Configure(EntityTypeBuilder<EventTable> builder)
    {
        builder.ToTable("EventTables")
        .HasKey(t => t.Id);

        builder.HasOne(p => p.OrderTable)
        .WithOne(p => p.EventTable)
        .HasForeignKey<OrderTable>(p => p.EventTableId)
        .IsRequired(false);
        
        builder.Property(p => p.Id);
    }
}