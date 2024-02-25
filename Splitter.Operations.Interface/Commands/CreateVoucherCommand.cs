namespace Splitter.Operations.Interface;

public class CreateVoucherCommand(Guid commandId, Guid commensalityId, decimal amount, int tip, bool isPartialPayment) : SptCommand(commandId)
{
    public Guid CommensalityId { get; set; } = commensalityId;
    public decimal Amount { get; set; } = amount;
    public int Tip { get; set; } = tip;
    public bool IsPartialPayment { get; set; } = isPartialPayment;
}
