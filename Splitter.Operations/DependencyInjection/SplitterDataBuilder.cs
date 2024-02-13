namespace Splitter.Operations;

public class SplitterDataBuilder(SplitterOperationsBuilder builder)
{
    public SplitterOperationsBuilder SplitterBuilder { get; } = builder;
}
