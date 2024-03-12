using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Commensality.Interface;

public class CreateProductCommand(Guid commandId, Guid commensalityId, Guid productId, string productName, decimal productPrice) : SptCommand(commandId)
{
    public Guid ProductId { get; set; } = productId;
    public Guid CommensalityId { get; set; } = commensalityId;
    public string ProductName { get; set; } = productName;
    public decimal ProductPrice { get; set; } = productPrice;
}
