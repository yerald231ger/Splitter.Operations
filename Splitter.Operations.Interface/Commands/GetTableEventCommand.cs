namespace Splitter.Operations.Interface;

public class GetEventTableCommand(Guid? orderId, DateTime? from, DateTime? to, bool withOrders = false) : SptCommand
{
    public Guid? EventTableId { get; set; } = orderId;
    public DateTime? From { get; set; } = from;
    public DateTime? To { get; set; } = to;
    public bool WithOrders { get; set; } = withOrders;
}
