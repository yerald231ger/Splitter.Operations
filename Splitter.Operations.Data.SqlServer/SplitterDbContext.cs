using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class SplitterDbContext(DbContextOptions<SplitterDbContext> options) : DbContext(options)
{
    public DbSet<EventTable> EventTables { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(SplitterDbContext).Assembly);
    }
}
