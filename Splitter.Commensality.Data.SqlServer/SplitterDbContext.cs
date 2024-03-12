using Microsoft.EntityFrameworkCore;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.Data.SqlServer;

public class SplitterDbContext(DbContextOptions<SplitterDbContext> options) : DbContext(options)
{
    public DbSet<Models.Commensality> Commensalitys { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> Products { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Commensality");
        builder.ApplyConfigurationsFromAssembly(typeof(SplitterDbContext).Assembly);
    }
}
