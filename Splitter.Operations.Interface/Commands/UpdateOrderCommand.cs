using Splitter.Operations.Constants;

namespace Splitter.Operations.Interface;

public class UpdateOrderCommand(Guid commandId, Guid commensalityId, OrderStatus status) : SptCommand(commandId)
{
    public Guid CommensalityId { get; set; } = commensalityId;
    public OrderStatus Status { get; set; } = status;
}
