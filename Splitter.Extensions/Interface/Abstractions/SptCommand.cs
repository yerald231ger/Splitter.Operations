namespace Splitter.Extentions.Interface.Abstractions;
public abstract class SptCommand
{
    public Guid CommandId { get; set; }
    public string GetCommandType() => GetType().FullName ?? string.Empty;

    public SptCommand() => CommandId = Guid.NewGuid();

    public SptCommand(Guid commandId) => CommandId = commandId;

    public SptCommand(Guid? commandId) => CommandId = commandId ?? Guid.NewGuid();
}