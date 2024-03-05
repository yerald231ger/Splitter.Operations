namespace Splitter.Extensions.Interface.Abstractions;
public abstract class SptCompletion : SptResult
{
    public SptCompletion(Guid commandId)
        : base(commandId)
    {
    }

    public SptCompletion()
    {
    }
}
