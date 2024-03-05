using Microsoft.Extensions.DependencyInjection;

namespace Splitter.BCMenu;

public static class SplitterMenuBuilderExtensions
{
    public static SplitterMenuBuilder AddMenu(this IServiceCollection services)
    {
        services.AddTransient<MenuService>();
        return new SplitterMenuBuilder(services);
    }

    public static SplitterDataBuilder AddData(this SplitterMenuBuilder builder)
    {
        return new SplitterDataBuilder(builder);
    }
}