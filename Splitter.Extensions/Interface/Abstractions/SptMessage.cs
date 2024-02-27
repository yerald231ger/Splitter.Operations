namespace Splitter.Extentions.Interface.Abstractions;
public abstract class SptMessage
{
    public string GetMessageType() => GetType().FullName ?? string.Empty;
}