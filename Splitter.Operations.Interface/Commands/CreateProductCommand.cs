namespace Splitter.Operations.Interface;

public class CreateProductCommand(Guid commandId, Guid commensalityId, string productName, decimal productPrice) : SptCommand(commandId)
{
    public Guid CommensalityId { get; set; } = commensalityId;
    public string ProductName { get; set; } = productName;
    public decimal ProductPrice { get; set; } = productPrice;
}
