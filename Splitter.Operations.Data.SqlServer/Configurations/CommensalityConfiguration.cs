using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;


public class CommensalityConfiguration : IEntityTypeConfiguration<Commensality>
{
    public void Configure(EntityTypeBuilder<Commensality> builder)
    {
        builder.ToTable("Commensalitys")
        .HasKey(t => t.Id);

        builder.HasOne(p => p.Order)
        .WithOne(p => p.Commensality)
        .HasForeignKey<Order>(p => p.CommensalityId)
        .IsRequired(false);
        
        builder.Property(p => p.Id);
    }
}