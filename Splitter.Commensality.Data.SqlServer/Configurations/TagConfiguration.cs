using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedOnAdd();
    }
}   
