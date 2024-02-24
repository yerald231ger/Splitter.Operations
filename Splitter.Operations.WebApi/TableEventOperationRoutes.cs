using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

public static class TableEventOperationRoutes
{
    public static void MapEvenTableOperationsRoute(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/tableevent");

        // Create a new event table
        routeGroup.MapPost("/", async (CreateEventTableCommand command, EventTableServices eventTableServices) =>
        {
            var result = await eventTableServices.CreateEvent(command);

            return result switch
            {
                SptCreateCompletion<EventTable> r => Results.Created($"/{r.Created!.Id}", r.ToDto()),
                SptRejection<SptRejectCodes> => Results.BadRequest(result),
                _ => Results.StatusCode(500)
            };

        })
        .Produces(201, responseType: typeof(EventTableDto))
        .Produces(400, responseType: typeof(SptRejection<SptRejectCodes>))
        .Produces(500)
        .WithOpenApi();

        // Add a product to an order
        routeGroup.MapPost("/{EventTableId:guid}/order/product", async (Guid eventTableId, CreateProductDto dto, EventTableServices eventTableServices) =>
        {
            var command = new CreateProductCommand(dto.CommandId, eventTableId, dto.ProductName, dto.ProductPrice);
            var result = await eventTableServices.OrderProduct(command);

            return result switch
            {
                SptCreateCompletion<Order> r => Results.Created($"/order/{r.Created!.Id}", r.ToDto()),
                SptRejection<SptRejectCodes> c => c.RejectionCode switch
                {
                    SptRejectCodes.OrderNotFound => Results.NotFound(result),
                    _ => Results.BadRequest(c)
                }
                ,
                _ => Results.StatusCode(500)
            };
        })
        .Produces(201, responseType: typeof(OrderDto))
        .Produces(400, responseType: typeof(SptRejection<SptRejectCodes>))
        .Produces(404)
        .Produces(500)
        .WithOpenApi();

        routeGroup.MapDelete("/{EventTableId:guid}/order/product/{ProductId:guid}", async (Guid? commandId, Guid eventTableId, Guid productId, EventTableServices eventTableServices) =>
        {
            var command = new DeleteTableEventProductCommand(commandId,eventTableId, productId);
            var result = await eventTableServices.DeleteProduct(command);
            return result switch
            {
                SptUpdateCompletion<Order> r => Results.NoContent(),
                SptRejection<SptRejectCodes> c => c.RejectionCode switch
                {
                    SptRejectCodes.OrderNotFound => Results.NotFound(result),
                    SptRejectCodes.EventTableNotFound => Results.NotFound(result),
                    SptRejectCodes.OrderWithoutProducts => Results.NotFound(result),
                    SptRejectCodes.NotFound => Results.NotFound(result),
                    _ => Results.BadRequest(c)
                }
                ,
                _ => Results.StatusCode(500)
            };
        });

        // Close an order
        routeGroup.MapPatch("/{EventTableId:guid}/order", async (Guid eventTableId, UpdateOrderDto dto, EventTableServices eventTableServices) =>
        {
            var command = new UpdateOrderCommand(dto.CommandId, eventTableId, dto.OrderStatus);
            var result = await eventTableServices.CloseOrder(command);
            return result switch
            {
                SptUpdateCompletion<Order> r => Results.NoContent(),
                SptRejection<SptRejectCodes> c => c.RejectionCode switch
                {
                    SptRejectCodes.OrderNotFound => Results.NotFound(result),
                    _ => Results.BadRequest(c)
                }
                ,
                _ => Results.StatusCode(500)
            };
        })
        .Produces(204)
        .Produces(400, responseType: typeof(SptRejection<SptRejectCodes>))
        .Produces(404)
        .Produces(500)
        .WithOpenApi();

        // Create a new payment to an order
        routeGroup.MapPost("/{EventTableId:guid}/order/voucher", async (Guid eventTableId, CreateVoucherDto dto, EventTableServices eventTableServices) =>
        {
            var command = new CreateVoucherCommand(dto.CommandId, eventTableId, dto.Amount, dto.Tip, dto.IsPartialPayment);
            SptResult result = command.IsPartialPayment ?
            await eventTableServices.PayPartialOrder(command) :
            await eventTableServices.PayTotalOrder(command);

            return result switch
            {
                SptCreateCompletion<Voucher> r => Results.Created($"/order/{r.Created!.Id}", r.ToDto()),
                SptRejection<SptRejectCodes> c => c.RejectionCode switch
                {
                    SptRejectCodes.OrderNotFound => Results.NotFound(result),
                    _ => Results.BadRequest(c)
                }
                ,
                _ => Results.StatusCode(500)
            };
        })
        .Produces(201, responseType: typeof(VoucherDto))
        .Produces(400, responseType: typeof(SptRejection<SptRejectCodes>))
        .Produces(404)
        .Produces(500)
        .WithOpenApi();
    }
}

