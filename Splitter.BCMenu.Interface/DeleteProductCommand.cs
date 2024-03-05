using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class DeleteProductCommand(Guid commandId, Guid menuId, Guid productId) : SptCommand(commandId)
{
    public Guid ProductId { get; set; } = productId;
    public Guid MenuId { get; set; } = menuId;
}
