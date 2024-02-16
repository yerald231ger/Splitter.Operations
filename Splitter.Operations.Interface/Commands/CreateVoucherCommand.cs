namespace Splitter.Operations.Interface;

public class CreateVoucherCommand(Guid commandId, Guid eventTableId, decimal amount, int tip, bool isPartialPayment) : SptCommand(commandId)
{
    public Guid EventTableId { get; set; } = eventTableId;
    public decimal Amount { get; set; } = amount;
    public int Tip { get; set; } = tip;
    public bool IsPartialPayment { get; set; } = isPartialPayment;
}
