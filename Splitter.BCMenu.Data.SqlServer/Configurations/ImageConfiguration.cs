using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images")
        .HasKey(t => t.Id);
        
        builder.Property(p => p.Id)
        .ValueGeneratedNever();
    }
}