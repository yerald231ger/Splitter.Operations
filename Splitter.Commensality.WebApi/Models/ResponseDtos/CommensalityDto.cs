using System.Text.Json.Serialization;
using Splitter.Extensions;

namespace Splitter.Commensality.WebApi;

public record GetCommensalityDto(Guid Id, string Name, DateTime CreatedAt) 
: ReponseDto
{

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OrderDto? Order { get; init; }
}