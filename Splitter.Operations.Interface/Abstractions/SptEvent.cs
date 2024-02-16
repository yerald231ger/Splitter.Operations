namespace Splitter.Operations.Interface;
public abstract class SptEvent
{
    public string GetEventType() => GetType().FullName ?? string.Empty;
}