using Splitter.Extensions;

namespace Splitter.BCMenu.WebApi;

public record CreateProductDto : RequestDto
{
    public Guid ProductId { get; init; }
    public Guid EstablishmentId { get; init; }
    public required string ProductName { get; init; }
    public decimal ProductPrice { get; init; }
}
