using Splitter.Extentions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class CreateProductCommand(Guid commandId, Guid menuId, Guid productId, string productName, decimal productPrice) : SptCommand(commandId)
{
    public Guid ProductId { get; set; } = productId;
    public Guid MenuId { get; set; } = menuId;
    public string ProductName { get; set; } = productName;
    public decimal ProductPrice { get; set; } = productPrice;
}
