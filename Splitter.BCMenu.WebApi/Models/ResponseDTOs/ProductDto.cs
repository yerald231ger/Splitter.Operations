using Splitter.Extensions;

namespace Splitter.BCMenu.WebApi;

public record class ProductDto : ReponseDto
{
    public Guid ProductId { get; init; }
    public Guid EstablishmentId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public decimal ProductPrice { get; init; }
}
