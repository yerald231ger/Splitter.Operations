using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Operations.Interface;

public class GetVoucherCommand(Guid? commandId, Guid? orderId, DateTime? from, DateTime? to)
 : SptCommand(commandId)
{
    public Guid? VoucherId { get; set; } = orderId;
    public DateTime? From { get; set; } = from;
    public DateTime? To { get; set; } = to;
}
