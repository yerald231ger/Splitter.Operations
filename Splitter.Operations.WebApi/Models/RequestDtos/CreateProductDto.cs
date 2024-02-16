namespace Splitter.Operations.WebApi;

public record CreateProductDto(string ProductName, decimal ProductPrice) : RequestDto;
