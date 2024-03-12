using Microsoft.Extensions.DependencyInjection;

namespace Splitter.Commensality;

public class SplitterOperationsBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services;
}