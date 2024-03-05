using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class UpdateProductCommand(Guid commandId, Guid menuId, Guid productId, string productName, decimal productPrice, string productDescription) : SptCommand(commandId)
{
    public Guid ProductId { get; set; } = productId;
    public Guid MenuId { get; set; } = menuId;
    public string ProductName { get; set; } = productName;
    public decimal ProductPrice { get; set; } = productPrice;
    public string ProductDescription { get; set; } = productDescription;
}
