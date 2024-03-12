using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class LayoutConfiguration : IEntityTypeConfiguration<MenuLayout>
{
    public void Configure(EntityTypeBuilder<MenuLayout> builder)
    {
        builder.ToTable("Layouts")
        .HasKey(t => t.Id);
        
        builder.Property(p => p.Id)
        .ValueGeneratedNever();
        
        builder.Property(p => p.Layout)
        .HasConversion(
            v => v == null ? null : v.RootElement.GetRawText(),
            v => JsonDocument.Parse(v!, new JsonDocumentOptions { AllowTrailingCommas = true })
        );
    }
}