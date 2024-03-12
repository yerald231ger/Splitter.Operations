using Splitter.Extensions.Interface.Abstractions;
using Splitter.Commensality.Constants;

namespace Splitter.Commensality.Interface;

public class UpdateOrderCommand(Guid commandId, Guid commensalityId, OrderStatus status) : SptCommand(commandId)
{
    public Guid CommensalityId { get; set; } = commensalityId;
    public OrderStatus Status { get; set; } = status;
}
