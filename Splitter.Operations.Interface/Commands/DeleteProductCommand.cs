namespace Splitter.Operations.Interface;

public class DeleteProductCommand(Guid? commandId, Guid? productId) : SptCommand(commandId)
{
    public Guid? ProductId { get; } = productId;
}
