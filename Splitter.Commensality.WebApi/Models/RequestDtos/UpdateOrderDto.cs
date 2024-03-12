using System.Text.Json.Serialization;
using Splitter.Extensions;
using Splitter.Commensality.Constants;

namespace Splitter.Commensality.WebApi;

public record UpdateOrderDto : RequestDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Closed;
}
