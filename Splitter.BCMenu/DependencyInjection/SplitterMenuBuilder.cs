using Microsoft.Extensions.DependencyInjection;

namespace Splitter.BCMenu;

public class SplitterMenuBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services;
}