﻿namespace Splitter.Commensality.WebApi;

public record GetCommensalitiesDto : ResponseManyDto<GetCommensalityDto>
{
    public GetCommensalitiesDto(Guid? commandId, IEnumerable<GetCommensalityDto> items)
    {
        this.items = items;
        CommandId = commandId;
    }
}