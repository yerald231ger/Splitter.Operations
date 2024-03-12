using Splitter.Extensions;

namespace Splitter.Commensality.WebApi;

public record CreateProductDto(Guid ProductId, string ProductName, decimal ProductPrice) : RequestDto;
