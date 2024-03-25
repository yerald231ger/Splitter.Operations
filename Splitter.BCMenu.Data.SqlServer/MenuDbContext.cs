using Microsoft.EntityFrameworkCore;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class MenuDbContext(DbContextOptions<MenuDbContext> options) : DbContext(options)
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<MenuLayout> MenuLayouts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("Menu");
        builder.ApplyConfigurationsFromAssembly(typeof(MenuDbContext).Assembly);
    }

}
