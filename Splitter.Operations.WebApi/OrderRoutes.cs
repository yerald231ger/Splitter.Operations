using Splitter.Operations.Infrastructure;

namespace Splitter.Operations.WebApi;

public static class OrderRoutes
{
    public static void MapOrderRoutes(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/order");

        routeGroup.MapGet("/", async(IOrderRepository orderRepository) =>
        {
            var result = await orderRepository.GetAsync();
            return Results.Ok(result);
        });
    }
}
