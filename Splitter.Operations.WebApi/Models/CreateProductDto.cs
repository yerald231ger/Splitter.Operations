namespace Splitter.Operations.WebApi;

public class CreateProductDto : RequestDto
{
    public required string ProductName { get; set; }
    public required decimal ProductPrice { get; set; }
}
