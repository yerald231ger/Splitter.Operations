using Splitter.Operations.Constants;

namespace Splitter.Operations.Interface;

public class UpdateOrderCommand(Guid commandId, Guid eventTableId, OrderStatus status) : SptCommand(commandId)
{
    public Guid EventTableId { get; set; } = eventTableId;
    public OrderStatus Status { get; set; } = status;
}
