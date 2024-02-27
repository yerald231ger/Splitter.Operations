namespace Splitter.Extentions.Interface.Abstractions;
public abstract class SptCommensality
{
    public string GetCommensalityType() => GetType().FullName ?? string.Empty;
}