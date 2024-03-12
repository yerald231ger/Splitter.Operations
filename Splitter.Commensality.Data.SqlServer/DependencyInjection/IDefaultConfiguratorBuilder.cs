using Microsoft.Extensions.DependencyInjection;

namespace Splitter.Commensality.Data.SqlServer;
public interface ISplitterSqlServerBuilder
{
    public IServiceCollection Services { get; }

}

public class SplitterSqlServerBuilder(IServiceCollection services) : ISplitterSqlServerBuilder
{
    public IServiceCollection Services
    {
        get;
    } = services;
}