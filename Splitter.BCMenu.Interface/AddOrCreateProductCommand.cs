using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class AddOrCreateProductCommand(Guid commandId, Guid establishmentId, Guid menuId, Guid productId, string productName, decimal productPrice) : SptCommand(commandId)
{
    public Guid ProductId { get; set; } = productId;
    public Guid EstablishmentId { get; set; } = establishmentId;
    public Guid MenuId { get; set; } = menuId;
    public string ProductName { get; set; } = productName;
    public decimal ProductPrice { get; set; } = productPrice;
}
