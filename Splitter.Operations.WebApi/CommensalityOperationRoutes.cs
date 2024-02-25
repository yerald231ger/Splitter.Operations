using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

public static class CommensalityOperationRoutes
{
    public static void MapCommensalityOperationsRoute(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/commensality");

        // Create a new Commensality
        routeGroup.MapPost("/", async (CreateCommensalityCommand command, CommensalityServices CommensalityServices) =>
        {
            var result = await CommensalityServices.CreateCommensality(command);

            return result switch
            {
                SptCreateCompletion<Commensality> r => Results.Created($"/{r.Created!.Id}", r.ToDto()),
                SptRejection<SptRejectCodes> => Results.BadRequest(result),
                _ => Results.StatusCode(500)
            };

        })
        .Produces(201, responseType: typeof(GetCommensalityDto))
        .Produces(400, responseType: typeof(SptRejection<SptRejectCodes>))
        .Produces(500)
        .WithOpenApi();

        // Add a product to an order
        routeGroup.MapPost("/{CommensalityId:guid}/order/product", async (Guid commensalityId, CreateProductDto dto, CommensalityServices CommensalityServices) =>
        {
            var command = new CreateProductCommand(dto.CommandId, commensalityId, dto.ProductName, dto.ProductPrice);
            var result = await CommensalityServices.OrderProduct(command);

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

        routeGroup.MapDelete("/{CommensalityId:guid}/order/product/{ProductId:guid}", async (Guid? commandId, Guid commensalityId, Guid productId, CommensalityServices CommensalityServices) =>
        {
            var command = new DeleteCommensalityProductCommand(commandId,commensalityId, productId);
            var result = await CommensalityServices.DeleteProduct(command);
            return result switch
            {
                SptUpdateCompletion<Order> r => Results.NoContent(),
                SptRejection<SptRejectCodes> c => c.RejectionCode switch
                {
                    SptRejectCodes.OrderNotFound => Results.NotFound(result),
                    SptRejectCodes.CommensalityNotFound => Results.NotFound(result),
                    SptRejectCodes.OrderWithoutProducts => Results.NotFound(result),
                    SptRejectCodes.NotFound => Results.NotFound(result),
                    _ => Results.BadRequest(c)
                }
                ,
                _ => Results.StatusCode(500)
            };
        });

        // Close an order
        routeGroup.MapPatch("/{CommensalityId:guid}/order", async (Guid commensalityId, UpdateOrderDto dto, CommensalityServices CommensalityServices) =>
        {
            var command = new UpdateOrderCommand(dto.CommandId, commensalityId, dto.OrderStatus);
            var result = await CommensalityServices.CloseOrder(command);
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
        routeGroup.MapPost("/{CommensalityId:guid}/order/voucher", async (Guid commensalityId, CreateVoucherDto dto, CommensalityServices CommensalityServices) =>
        {
            var command = new CreateVoucherCommand(dto.CommandId, commensalityId, dto.Amount, dto.Tip, dto.IsPartialPayment);
            SptResult result = command.IsPartialPayment ?
            await CommensalityServices.PayPartialOrder(command) :
            await CommensalityServices.PayTotalOrder(command);

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

