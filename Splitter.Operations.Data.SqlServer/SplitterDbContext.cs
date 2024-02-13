using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class SplitterDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EventTable> EventTables { get; set; }
    public DbSet<OrderTable> OrderTables { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventTable>(builder =>
        {
            builder.HasKey((e) => e.Id);
            builder.Property((e) => e.Id).ValueGeneratedOnAdd();
            builder.Property((e) => e.Name).IsRequired();
        });
    }
}
