using Splitter.Extensions;
using Splitter.Operations.Constants;
using System.Text.Json.Serialization;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record class OrderDto(
    Guid? commandId,
    Guid id,
    decimal total,
    decimal totalPaid,
    List<ProductDto> products,
    List<VoucherDto> vouchers)
    : ReponseDto(commandId)
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderStatus orderStatus { get; set; }
}
#pragma warning restore IDE1006 // Naming Styles
