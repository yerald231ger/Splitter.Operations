namespace Splitter.Operations.Interface;

public class GetProductCommand(Guid? orderId) : SptCommand
{
    public Guid? ProductId { get; set; } = orderId;
}
