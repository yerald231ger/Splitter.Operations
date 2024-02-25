namespace Splitter.Operations.WebApi;

public record GetCommensalitysDto : ResponseManyDto<GetCommensalityDto>
{
    public GetCommensalitysDto(Guid? commandId, IEnumerable<GetCommensalityDto> items)
    {
        this.items = items;
        this.commandId = commandId;
    }
}
