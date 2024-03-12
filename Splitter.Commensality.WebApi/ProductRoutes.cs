using Splitter.Extensions.Interface.Abstractions;
using Splitter.Commensality.Constants;
using Splitter.Commensality.Interface;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.WebApi;

public static class ProductRoutes
{
    public static void MapProductRoutes(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/product");

        routeGroup.MapGet("/", async (Guid? commandId, Guid? id, ProductService productService) =>
        {
            var command = new GetProductCommand(commandId, id);
            var result = await productService.GetProductsAsync(command);
            return result switch
            {
                SptGetManyCompletion<OrderProduct> r => Results.Ok(r.ToDto()),
                SptRejection<CommensalityRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetProductsDto>()
        .Produces<SptRejection<CommensalityRejectCodes>>(400)
        .WithOpenApi();

        routeGroup.MapDelete("/{id:guid}", async (Guid? commanId, Guid id, ProductService productService) =>
        {
            var command = new DeleteProductCommand(commanId, id);
            var result = await productService.DeleteProductAsync(command);
            return result switch
            {
                SptUpdateCompletion<OrderProduct> r => Results.NoContent(),
                SptRejection<CommensalityRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces(204)
        .Produces<SptRejection<CommensalityRejectCodes>>(400)
        .WithOpenApi();

    }
}
