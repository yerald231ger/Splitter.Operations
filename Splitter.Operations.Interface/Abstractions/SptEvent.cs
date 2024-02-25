namespace Splitter.Operations.Interface;
public abstract class SptCommensality
{
    public string GetCommensalityType() => GetType().FullName ?? string.Empty;
}