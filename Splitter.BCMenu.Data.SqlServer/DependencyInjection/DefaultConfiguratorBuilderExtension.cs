﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Splitter.BCMenu;
using Splitter.BCMenu.Data.SqlServer;
using Splitter.BCMenu.Infrastructure;

namespace Splitter.Commensality.Data.SqlServer;

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
        builder.SplitterBuilder.Services.AddScoped<IMenuRepository, MenuRepository>();
        builder.SplitterBuilder.Services.AddScoped<IMenuUnitOfWork, MenuUnitOfWork>();

        builder.SplitterBuilder.Services.AddDbContext<MenuDbContext>(options =>
        {
            if (isInMemory)
                options.UseInMemoryDatabase("Splitter.Menu");
            else
            {
                var connectionString = configuration.GetConnectionString("SplitterMenuDb");
                options.UseSqlServer(connectionString);
            }
        });
        return builder;
    }
}
