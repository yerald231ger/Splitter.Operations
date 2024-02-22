namespace Splitter.Operations.WebApi;

public record GetEventTablesDto : ResponseManyDto<EventTableDto>
{
    public GetEventTablesDto(Guid? commandId, IEnumerable<EventTableDto> items)
    {
        this.items = items;
        this.commandId = commandId;
    }
}
