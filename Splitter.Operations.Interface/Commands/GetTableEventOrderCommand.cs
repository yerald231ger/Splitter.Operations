namespace Splitter.Operations.Interface;

public class GetTableEventOrderCommand(Guid? commandId, Guid eventTableId, Guid orderId) : SptCommand(commandId)
{
    public Guid EventTableId { get; } = eventTableId;
    public Guid? OrderId { get; } = orderId;
}
