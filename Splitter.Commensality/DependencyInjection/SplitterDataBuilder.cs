namespace Splitter.Commensality;

public class SplitterDataBuilder(SplitterOperationsBuilder builder)
{
    public SplitterOperationsBuilder SplitterBuilder { get; } = builder;
}
