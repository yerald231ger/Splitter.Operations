namespace Splitter.Operations.Interface;
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
