using Microsoft.EntityFrameworkCore;

namespace Splitter.Operations.Rest;

public class SplitterDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EventTable> EventTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventTable>(builder =>
        {
            builder.HasKey((e) => e.Id);
            builder.Property((e) => e.Id).ValueGeneratedOnAdd();
            builder.Property((e) => e.Name).IsRequired();
            builder.Property((e) => e.Content).IsRequired();
        });
    }
}
