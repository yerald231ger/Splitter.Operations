namespace Splitter.Operations.WebApi;

public record CreateProductDto(Guid ProductId, string ProductName, decimal ProductPrice) : RequestDto;
