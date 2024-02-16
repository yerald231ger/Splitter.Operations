
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

public static class ToDtoExtension
{
    public static EventTableDto ToDto(this SptCreateCompletion<EventTable> eventTable)
    => new(
        eventTable.CommandId,
        eventTable.Created!.Id,
        eventTable.Created.Name,
        eventTable.Created.CreatedAt);

    public static OrderDto ToDto(this SptCreateCompletion<Order> order)
    => new(
        order.CommandId,
        order.Created!.Id,
        order.Created.Total,
        order.Created.TotalPaid,
        order.Created.Products?.Select(p => p.ToDto()).ToList() ?? [],
        order.Created.Vouchers?.Select(p => p.ToDto()).ToList() ?? [])
    {
        orderStatus = order.Created.Status
    };

    public static VoucherDto ToDto(this SptCreateCompletion<Voucher> voucher)
    => new(
        voucher.CommandId,
        voucher.Created!.Id,
        voucher.Created.Amount,
        voucher.Created.Total,
        voucher.Created.Total - voucher.Created.Amount,
        voucher.Created.CreatedAt,
        voucher.Created.OrderId);

    public static ProductVODto ToDto(this Product product) => new(product.Id, product.Name, product.Price);
    public static VoucherVODto ToDto(this Voucher voucher) => new(voucher.Id, voucher.Amount, voucher.Total, voucher.Total - voucher.Amount, voucher.CreatedAt, voucher.OrderId);
}