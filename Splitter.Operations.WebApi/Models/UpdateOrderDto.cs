using System.Text.Json.Serialization;
using Splitter.Operations.Constants;

namespace Splitter.Operations.WebApi;

public class UpdateOrderDto : RequestDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Closed;
}
