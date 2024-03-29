﻿using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

public static class TableEventRoutes
{
    public static void MapTableEventRoutes(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/tablevent");

        routeGroup.MapGet("/", async (Guid? id, DateTime? from, DateTime? to, EventTableServices orderService, bool withOrders = false) =>
        {
            var command = new GetEventTableCommand(id, from, to, withOrders);
            var result = await orderService.GetEventTablesAsync(command);
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
