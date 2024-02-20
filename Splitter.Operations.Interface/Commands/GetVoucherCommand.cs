namespace Splitter.Operations.Interface;

public class GetVoucherCommand(Guid? orderId, DateTime? from, DateTime? to) : SptCommand
{
    public Guid? VoucherId { get; set; } = orderId;
    public DateTime? From { get; set; } = from;
    public DateTime? To { get; set; } = to;
}
