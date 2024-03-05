namespace Splitter.Extensions.Interface.Abstractions;
public abstract class SptMessage
{
    public string GetMessageType() => GetType().FullName ?? string.Empty;
}