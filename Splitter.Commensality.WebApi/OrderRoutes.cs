using Splitter.Extensions.Interface.Abstractions;
using Splitter.Commensality.Constants;
using Splitter.Commensality.Interface;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.WebApi;

public static class OrderRoutes
{
    public static void MapOrderRoutes(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/order");

        routeGroup.MapGet("/", async (Guid? commandId, Guid? id, DateTime? from, DateTime? to, OrderService orderService, bool withProducts = false, bool withVouchers = false) =>
        {
            var command = new GetOrderCommand(commandId, id, from, to, withProducts, withVouchers);
            var result = await orderService.GetOrdersAsync(command);
            return result switch
            {
                SptGetManyCompletion<Order> r => Results.Ok(r.ToDto()),
                SptRejection<CommensalityRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetOrdersDto>()
        .Produces<SptRejection<CommensalityRejectCodes>>(400)
        .WithOpenApi();


    }
}
