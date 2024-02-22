namespace Splitter.Operations.WebApi;

public record GetProductsDto : ResponseManyDto<ProductDto>
{
    public GetProductsDto(Guid? commandId, IEnumerable<ProductDto> items)
    {
        this.items = items;
        this.commandId = commandId;
    }
}   
