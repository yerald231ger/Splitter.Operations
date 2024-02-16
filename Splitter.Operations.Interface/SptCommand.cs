namespace Splitter.Operations.Interface;

public abstract class SptCommand
{
    public Guid CommandId { get; set; }
    public SptCommand() => CommandId = Guid.NewGuid();

    public SptCommand(Guid commandId) => CommandId = Guid.NewGuid();
}
