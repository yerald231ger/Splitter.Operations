namespace Splitter.Operations.Interface;

public class DeleteTableEventProductCommand(Guid? commandId, Guid tableEventId, Guid productId) : SptCommand(commandId)
{
    public Guid TableEventId { get; set; } = tableEventId;
    public Guid ProductId { get; set; } = productId;
}
