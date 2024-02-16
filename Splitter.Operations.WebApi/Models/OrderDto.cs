using Splitter.Operations.Models;
using System.Linq;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record class OrderDto(
    Guid id,
    decimal total,
    string status,
    List<ProductDto> products,
    List<VoucherDto> vouchers)
{
    internal static OrderDto ToDto(Order order) =>
        new(order.Id, order.Total, order.Status.ToString(),
            order.Products?.Select(ProductDto.ToDto).ToList() ?? [],
            order.Vouchers?.Select(VoucherDto.ToDto).ToList() ?? []);
}
#pragma warning restore IDE1006 // Naming Styles
