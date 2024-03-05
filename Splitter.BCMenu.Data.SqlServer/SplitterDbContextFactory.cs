using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Splitter.BCMenu.Data.SqlServer;

public class SplitterDbContextFactory : IDesignTimeDbContextFactory<MenuDbContext>
{
    public MenuDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MenuDbContext>();
        optionsBuilder.UseSqlServer();

        return new MenuDbContext(optionsBuilder.Options);
    }
}