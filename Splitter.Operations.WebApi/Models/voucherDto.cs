using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

#pragma warning disable IDE1006 // Naming Styles
public record VoucherDto(
    Guid id,
    decimal amount,
    decimal total,
    decimal tipAmount,
    DateTime createdAt,
    Guid orderTableId)
{
    public static VoucherDto ToDto(Voucher voucher) => new(
        voucher.Id,
        voucher.Amount,
        voucher.Total,
        voucher.Total - voucher.Amount,
        voucher.CreatedAt,
        voucher.OrderTableId);
}
#pragma warning restore IDE1006 // Naming Styles