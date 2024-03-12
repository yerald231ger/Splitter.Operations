using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;


public class CommensalityConfiguration : IEntityTypeConfiguration<Models.Commensality>
{
    public void Configure(EntityTypeBuilder<Models.Commensality> builder)
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