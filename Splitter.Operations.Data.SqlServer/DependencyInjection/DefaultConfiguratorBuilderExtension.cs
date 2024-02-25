using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Splitter.Operations.Infrastructure;

namespace Splitter.Operations.Data.SqlServer;

public static class DefaultConfiguratorBuilderExtension
{
    public static SplitterDataBuilder AddInMemory(this SplitterDataBuilder builder)
    {
        return builder.DataBuilder(null!, ServiceLifetime.Scoped, true);
    }

    public static SplitterDataBuilder AddSqlServer(
        this SplitterDataBuilder builder,
        IConfiguration configuration,
    ServiceLifetime lifeTime = ServiceLifetime.Scoped)
    {
        return builder.DataBuilder(configuration, lifeTime, false);
    }

    private static SplitterDataBuilder DataBuilder(
        this SplitterDataBuilder builder,
        IConfiguration configuration,
    ServiceLifetime lifeTime = ServiceLifetime.Scoped, bool isInMemory = false)
    {
        builder.SplitterBuilder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.SplitterBuilder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.SplitterBuilder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
        builder.SplitterBuilder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.SplitterBuilder.Services.AddScoped<ICommensalityRepository, CommensalityRepository>();
        builder.SplitterBuilder.Services.AddScoped<ICommensalityUnitOfWork, CommensalityUnitOfWork>();

        builder.SplitterBuilder.Services.AddDbContext<SplitterDbContext>(options =>
        {
            if (isInMemory)
                options.UseInMemoryDatabase("SplitterDb");
            else
            {
                var connectionString = configuration.GetConnectionString("SplitterDb");
                options.UseSqlServer(connectionString);
                options.EnableDetailedErrors(false);
                options.EnableSensitiveDataLogging(false);
            }
        });
        return builder;
    }
}
