using Splitter.Extentions.Interface.Abstractions;

namespace Splitter.Operations.Interface;

public class CreateVoucherCommand(Guid commandId, Guid commensalityId, Guid voucherId, decimal amount, int tip, bool isPartialPayment) : SptCommand(commandId)
{
    public Guid VoucherId { get; set; } = voucherId;
    public Guid CommensalityId { get; set; } = commensalityId;
    public decimal Amount { get; set; } = amount;
    public int Tip { get; set; } = tip;
    public bool IsPartialPayment { get; set; } = isPartialPayment;
}
