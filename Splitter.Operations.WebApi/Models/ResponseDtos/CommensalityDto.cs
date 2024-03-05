using System.Text.Json.Serialization;
using Splitter.Extensions;

namespace Splitter.Operations.WebApi;

public record GetCommensalityDto(Guid Id, string Name, DateTime CreatedAt) 
: ReponseDto
{

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OrderDto? Order { get; init; }
}