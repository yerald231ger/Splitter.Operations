using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.Commensality.Interface;

public class DeleteProductCommand(Guid? commandId, Guid? productId) : SptCommand(commandId)
{
    public Guid? ProductId { get; } = productId;
}
