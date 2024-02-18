namespace Splitter.Operations.Interface;

public class GetOrderCommand(Guid? orderId, DateTime? from, DateTime? to) : SptCommand
{
    public Guid? OrderId { get; set; } = orderId;
    public DateTime? From { get; set; } = from;
    public DateTime? To { get; set; } = to;
}
