namespace Splitter.Operations.Interface;

public class GetProductCommand(Guid? commandId, Guid? orderId)
 : SptCommand(commandId)
{
    public Guid? ProductId { get; set; } = orderId;
    public string Name { get; set; } = string.Empty;
}
