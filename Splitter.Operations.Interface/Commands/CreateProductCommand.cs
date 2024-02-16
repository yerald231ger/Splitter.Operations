namespace Splitter.Operations.Interface;

public class CreateProductCommand(Guid commandId, Guid eventTableId, string productName, decimal productPrice) : SptCommand(commandId)
{
    public Guid EventTableId { get; set; } = eventTableId;
    public string ProductName { get; set; } = productName;
    public decimal ProductPrice { get; set; } = productPrice;
}
