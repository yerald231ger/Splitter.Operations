namespace Splitter.Commensality.WebApi;

public record GetOrdersDto : ResponseManyDto<OrderDto>
{
    public GetOrdersDto(Guid? commandId, IEnumerable<OrderDto> items)
    {
        this.items = items;
        CommandId = commandId;
    }
    
}