using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Splitter.Operations.Infrastructure;

namespace Splitter.Operations.Data.SqlServer;

public static class DefaultConfiguratorBuilderExtension
{

    public static SplitterDataBuilder AddSqlServer(
        this SplitterDataBuilder builder,
        IConfiguration configuration,
    ServiceLifetime lifeTime = ServiceLifetime.Scoped)
    {
        builder.SplitterBuilder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.SplitterBuilder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.SplitterBuilder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
        builder.SplitterBuilder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.SplitterBuilder.Services.AddScoped<IEventTableRepository, EventTableRepository>();
        builder.SplitterBuilder.Services.AddScoped<IEventTableUnitOfWork, EventTableUnitOfWork>();

        builder.SplitterBuilder.Services.AddDbContext<SplitterDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("SplitterDb");
            options.UseSqlServer(connectionString);
            options.EnableDetailedErrors(false);
            options.EnableSensitiveDataLogging(false);
        });
        return builder;
    }

}
