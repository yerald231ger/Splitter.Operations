using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Operations.Interface;

public class GetCommensalityCommand(Guid? commandId, Guid? orderId, DateTime? from, DateTime? to, bool withOrders = false)
 : SptCommand(commandId)
{
    public Guid? CommensalityId { get; set; } = orderId;
    public DateTime? From { get; set; } = from;
    public DateTime? To { get; set; } = to;
    public bool WithOrders { get; set; } = withOrders;
}
