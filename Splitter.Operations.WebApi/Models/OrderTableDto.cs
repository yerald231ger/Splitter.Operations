using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record class OrderTableDto(
    Guid id,
    decimal total,
    string status
)
{
    internal static OrderTableDto ToDto(OrderTable orderTable) =>
        new(orderTable.Id, orderTable.Total, orderTable.Status.ToString());
}
#pragma warning restore IDE1006 // Naming Styles