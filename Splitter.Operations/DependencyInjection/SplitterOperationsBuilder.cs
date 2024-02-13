using Microsoft.Extensions.DependencyInjection;

namespace Splitter.Operations;

public class SplitterOperationsBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services;
}