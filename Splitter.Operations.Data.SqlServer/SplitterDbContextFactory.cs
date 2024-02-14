using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Splitter.Operations.Data.SqlServer;

public class SplitterDbContextFactory : IDesignTimeDbContextFactory<SplitterDbContext>
{
    public SplitterDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SplitterDbContext>();
        optionsBuilder.UseSqlServer();

        return new SplitterDbContext(optionsBuilder.Options);
    }
}

// public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
//     {

//         MyDbContext IDesignTimeDbContextFactory<MyDbContext>.CreateDbContext(string[] args)
//         {
//             IConfigurationRoot configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json")
//                 .Build();

//             var builder = new DbContextOptionsBuilder<MyDbContext>();
//             var connectionString = configuration.GetConnectionString("DefaultConnection");

//             builder.UseSqlServer(connectionString);

//             return new MyDbContext(builder.Options);
//         }
//     }