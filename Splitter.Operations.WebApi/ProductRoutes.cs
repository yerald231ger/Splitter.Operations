using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

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
                SptGetManyCompletion<Product> r => Results.Ok(r.ToDto()),
                SptRejection<SptRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetProductsDto>()
        .Produces<SptRejection<SptRejectCodes>>(400)
        .WithOpenApi();

        routeGroup.MapDelete("/{id:guid}", async (Guid? commanId, Guid id, ProductService productService) =>
        {
            var command = new DeleteProductCommand(commanId, id);
            var result = await productService.DeleteProductAsync(command);
            return result switch
            {
                SptUpdateCompletion<Product> r => Results.NoContent(),
                SptRejection<SptRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces(204)
        .Produces<SptRejection<SptRejectCodes>>(400)
        .WithOpenApi();

    }
}
