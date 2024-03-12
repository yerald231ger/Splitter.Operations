using Splitter.Extensions;

namespace Splitter.Commensality.WebApi;

#pragma warning disable IDE1006 // Remove unused private members
public record ResponseManyDto<TDto> : ReponseDto
{
    public IEnumerable<TDto> items { get; set; } = [];
}

#pragma warning restore IDE1006 // Remove unused private members