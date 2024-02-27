using Splitter.Extentions.Interface.Abstractions;
using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

public static class CommensalityRoutes
{
    public static void MapCommensalityRoutes(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/commensality");

        routeGroup.MapGet("/{commensalityId:guid}", async (Guid? commandId, Guid? commensalityId, CommensalityServices commensalityService, bool withOrders = false) =>
        {
            var command = new GetCommensalityCommand(commandId, commensalityId, null, null, withOrders);
            var result = await commensalityService.GetCommensalitysAsync(command);
            return result switch
            {
                SptGetCompletion<Commensality> r => Results.Ok(r.ToDto()),
                SptRejection<CommensalityRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetCommensalitysDto>()
        .Produces<SptRejection<CommensalityRejectCodes>>(400)
        .WithOpenApi();

        routeGroup.MapGet("/", async (Guid? commandId, DateTime? from, DateTime? to, CommensalityServices commensalityService, bool withOrders = false) =>
        {
            var command = new GetCommensalityCommand(commandId, null, from, to, false);
             var result = await commensalityService.GetCommensalitysAsync(command);
            return result switch
            {
                SptGetManyCompletion<Commensality> r => Results.Ok(r.ToDto()),
                SptRejection<CommensalityRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetCommensalitysDto>()
        .Produces<SptRejection<CommensalityRejectCodes>>(400)
        .WithOpenApi();
    }
}
