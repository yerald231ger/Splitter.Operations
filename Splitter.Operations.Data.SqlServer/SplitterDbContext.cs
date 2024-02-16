using Microsoft.EntityFrameworkCore;
using Splitter.Operations.Models;

namespace Splitter.Operations.Data.SqlServer;

public class SplitterDbContext : DbContext
{
    public DbSet<EventTable> EventTables { get; set; }
    public DbSet<Order> OrderTables { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public SplitterDbContext(DbContextOptions<SplitterDbContext> options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options =>
        {
            options.MigrationsHistoryTable("__MigrationsHistory");
        });
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    
        builder.ApplyConfigurationsFromAssembly(typeof(SplitterDbContext).Assembly);

    }
}
