using System.Text.Json.Serialization;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record GetCommensalityDto(Guid? commandId, Guid id, string name, DateTime createdAt, OrderDto? order) : ReponseDto(commandId)
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OrderDto? order { get; init; } = order;
}
#pragma warning restore IDE1006 // Naming Styles