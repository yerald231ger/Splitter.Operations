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
    internal static OrderDto ToDto(Order orderTable) =>
        new(orderTable.Id, orderTable.Total, orderTable.Status.ToString(),
            orderTable.Products?.Select(ProductDto.ToDto).ToList() ?? [],
            orderTable.Vouchers?.Select(VoucherDto.ToDto).ToList() ?? []);
}
#pragma warning restore IDE1006 // Naming Styles
