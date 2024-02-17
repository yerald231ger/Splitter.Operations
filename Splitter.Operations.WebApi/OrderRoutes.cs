using Microsoft.AspNetCore.Mvc;
using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

public class P{
    public int MyProperty { get; set; }
}

public static class OrderRoutes
{
    public static void MapOrderRoutes(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/order");

        routeGroup.MapGet("/", async (Guid id, Guid? commandId, DateTime? from, DateTime? to, OrderService orderService) =>
        {
            var result = await orderService.GetOrdersAsync(new GetOrderCommand(id, from, to));
            return result switch
            {
                SptGetManyCompletion<Order> r => Results.Ok(r.Items.Select(x => x.ToDto()).ToList()),
                SptRejection<SptRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<List<OrderDto>>()
        .Produces<SptRejection<SptRejectCodes>>(400)
        .WithOpenApi();
    }
}
