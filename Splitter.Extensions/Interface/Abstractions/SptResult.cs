namespace Splitter.Extensions.Interface.Abstractions;
public abstract class SptResult
{
    public Guid CommandId { get; set; }

    public SptResult(Guid commandId) => CommandId = commandId;

    public SptResult()
    {
    }
}