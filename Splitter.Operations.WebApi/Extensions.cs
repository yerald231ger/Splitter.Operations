using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

public static class ToDtoExtension
{
    public static GetCommensalityDto ToDto(this SptCreateCompletion<Commensality> commensality)
    => new(
        commensality.CommandId,
        commensality.Created!.Id,
        commensality.Created.Name,
        commensality.Created.CreatedAt,
        null);

    public static GetCommensalityDto ToDto(this Commensality commensality, Guid commandId)
    => new(commandId, commensality.Id, commensality.Name, commensality.CreatedAt, null);

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

    public static GetOrdersDto ToDto(this SptGetManyCompletion<Order> orders)
    {
        var orderDTos = orders.Items.Select(o =>
        {
            var orderDto = new OrderDto(
                null,
                o.Id,
                o.Total,
                o.TotalPaid,
                o.Products?.Select(p => p.ToDto()).ToList() ?? [],
                o.Vouchers?.Select(p => p.ToDto()).ToList() ?? [])
            {
                orderStatus = o.Status
            };

            return orderDto;
        });

        return new GetOrdersDto(orders.CommandId, orderDTos);
    }

    public static GetProductsDto ToDto(this SptGetManyCompletion<Product> product)
    {
        var productDtos = product.Items.Select(p => new ProductDto(p.Id, p.Name, p.Price));
        return new GetProductsDto(product.CommandId, productDtos);
    }

    public static GetCommensalityDto ToDto(this SptGetCompletion<Commensality> result)
    {
        OrderDto? order = null;
        if (result.Item!.Order != null)
            order = new OrderDto(null, result.Item!.Order!.Id, result.Item!.Order.Total, result.Item!.Order.TotalPaid, [], []);
        var commensalityDto = new GetCommensalityDto(result.CommandId, result.Item!.Id, result.Item.Name, result.Item.CreatedAt, order);
        return commensalityDto;
    }

    public static GetVouchersDto ToDto(this SptGetManyCompletion<Voucher> vouchers)
    {
        var voucherDtos = vouchers.Items.Select(v => new VoucherDto(null, v.Id, v.Amount, v.Total, v.Total - v.Amount, v.CreatedAt, v.OrderId));
        return new GetVouchersDto(vouchers.CommandId, voucherDtos);
    }

    public static GetCommensalitysDto ToDto(this SptGetManyCompletion<Commensality> Commensalitys)
    {
        var CommensalityDtos = Commensalitys.Items.Select(e => new GetCommensalityDto(Commensalitys.CommandId, e.Id, e.Name, e.CreatedAt, null));
        return new GetCommensalitysDto(Commensalitys.CommandId, CommensalityDtos);
    }

    public static VoucherDto ToDto(this SptCreateCompletion<Voucher> voucher)
    => new(
        voucher.CommandId,
        voucher.Created!.Id,
        voucher.Created.Amount,
        voucher.Created.Total,
        voucher.Created.Total - voucher.Created.Amount,
        voucher.Created.CreatedAt,
        voucher.Created.OrderId);

    public static ProductDto ToDto(this Product product) => new(product.Id, product.Name, product.Price);
    public static VoucherDto ToDto(this Voucher voucher) => new(null, voucher.Id, voucher.Amount, voucher.Total, voucher.Total - voucher.Amount, voucher.CreatedAt, voucher.OrderId);
}