using System.Text.Json.Serialization;
using Splitter.Extensions;
using Splitter.Operations.Constants;

namespace Splitter.Operations.WebApi;

public record UpdateOrderDto : RequestDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Closed;
}
