namespace Splitter.Operations.Interface;
public abstract class SptMessage
{
    public string GetMessageType() => GetType().FullName ?? string.Empty;
}