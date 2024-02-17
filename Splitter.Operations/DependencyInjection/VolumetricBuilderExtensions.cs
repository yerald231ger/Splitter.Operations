using Microsoft.Extensions.DependencyInjection;

namespace Splitter.Operations;

public static class VolumetricBuilderExtensions
{
    public static SplitterOperationsBuilder AddEventTableService(this IServiceCollection services)
    {
        services.AddTransient<EventTableServices>();
        services.AddTransient<OrderService>();
        return new SplitterOperationsBuilder(services);
    }

    public static SplitterDataBuilder AddData(this SplitterOperationsBuilder builder)
    {
        return new SplitterDataBuilder(builder);
    }
}