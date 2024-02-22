using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

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
                SptRejection<SptRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetOrdersDto>()
        .Produces<SptRejection<SptRejectCodes>>(400)
        .WithOpenApi();


    }
}
