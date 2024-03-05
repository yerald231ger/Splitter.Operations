namespace Splitter.Extensions.Interface.Abstractions;
public abstract class SptCommensality
{
    public string GetCommensalityType() => GetType().FullName ?? string.Empty;
}