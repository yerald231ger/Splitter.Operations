namespace Splitter.Operations.WebApi;

public static class TableEventRoute
{
    public static void MapEvenTableRoute(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/tableevent");

        // Create a new event table
        routeGroup.MapPost("/", async (string name, EventTableServices eventTableServices, ILogger<Program> logger) =>
        {
            try
            {
                var eventTable = await eventTableServices.CreateEvent(name);

                return Results.Created($"/{eventTable.Id}",
                    EventTableDto.ToDto(eventTable));
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error while creating EventTable");
                return Results.StatusCode(500);
            }
        })
        .Produces(201, responseType: typeof(EventTableDto))
        .WithOpenApi();

        // Add a product to an order
        routeGroup.MapPost("/{id:guid}/ordertable/product", async (Guid id, string productName, decimal productPrice, EventTableServices eventTableServices, ILogger<Program> logger) =>
        {
            try
            {
                var orderTable = await eventTableServices.OrderProduct(id, productName, productPrice);

                return Results.Created($"/ordertable/{orderTable.Id}",
                    OrderTableDto.ToDto(orderTable));
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error while ordering product");
                return Results.StatusCode(500);
            }
        }).Produces(201, responseType: typeof(OrderTableDto));

        // Close an order
        routeGroup.MapPatch("/{id:guid}/ordertable", async (Guid id, EventTableServices eventTableServices, ILogger<Program> logger, string status = "closed") =>
        {
            try
            {
                await eventTableServices.CloseOrder(id);
                return Results.NoContent();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error while closing order");
                return Results.StatusCode(500);
            }
        }).Produces(204);

        // Create a new payment to an order
        routeGroup.MapPost("/{id:guid}/ordertable/voucher", async (Guid id, decimal amount, int tip, bool isPartialPayment, EventTableServices eventTableServices, ILogger<Program> logger) =>
        {
            try
            {
                if (isPartialPayment)
                {
                    var voucher = await eventTableServices.PayPartialOrder(id, amount, tip);
                    return Results.Created($"/ordertable/{voucher.OrderTableId}",
                        VoucherDto.ToDto(voucher));
                }
                else
                {
                    var voucher = await eventTableServices.PayTotalOrder(id, amount, tip);
                    return Results.Created($"/ordertable/{voucher.OrderTableId}",
                        VoucherDto.ToDto(voucher));
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error while paying order");
                return Results.StatusCode(500);
            }
        }).Produces(201, responseType: typeof(VoucherDto));
    }
}

