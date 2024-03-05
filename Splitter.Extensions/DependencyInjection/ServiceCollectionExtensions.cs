using Microsoft.Extensions.DependencyInjection;
using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Extensions;

public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddCommandBuilder(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.Add(ServiceDescriptor.Describe(typeof(ISptInterface), typeof(SptInterface), serviceLifetime));
        return services;
    }
}