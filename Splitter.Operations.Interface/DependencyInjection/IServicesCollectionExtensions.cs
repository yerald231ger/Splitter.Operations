using Microsoft.Extensions.DependencyInjection;

namespace Splitter.Operations.Interface;
public static class IServicesCollectionExtensions
{
    public static IServiceCollection AddCommandBuilder(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.Add(ServiceDescriptor.Describe(typeof(ISptInterface), typeof(SptInterface), serviceLifetime));
        return services;
    }
}