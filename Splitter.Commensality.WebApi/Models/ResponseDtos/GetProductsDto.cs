namespace Splitter.Commensality.WebApi;

public record GetProductsDto : ResponseManyDto<ProductDto>
{
    public GetProductsDto(Guid? commandId, IEnumerable<ProductDto> items)
    {
        this.items = items;
        CommandId = commandId;
    }
}   
