using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Splitter.Operations.Infrastructure;

namespace Splitter.Operations.Data.SqlServer;

public static class DefaultConfiguratorBuilderExtension
{

    public static SplitterDataBuilder AddSqlServer(
        this SplitterDataBuilder builder,
    ServiceLifetime lifeTime = ServiceLifetime.Scoped)
    {
        builder.SplitterBuilder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.SplitterBuilder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.SplitterBuilder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
        builder.SplitterBuilder.Services.AddScoped<IOrderTableRepository, OrderTableRepository>();
        builder.SplitterBuilder.Services.AddScoped<IEventTableRepository, EventTableRepository>();
        builder.SplitterBuilder.Services.AddScoped<IEventTableUnitOfWork, EventTableUnitOfWork>();

        builder.SplitterBuilder.Services.AddDbContext<SplitterDbContext>(options =>
        {
            options.UseSqlServer("Server=tcp:splitterserver.database.windows.net,1433;Initial Catalog=splitterdb;Persist Security Info=False;User ID=splitteradmin;Password=mevmiz-8zovnU-cywqoh;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            options.EnableDetailedErrors(false);
            options.EnableSensitiveDataLogging(false);
        });
        return builder;
    }

}
