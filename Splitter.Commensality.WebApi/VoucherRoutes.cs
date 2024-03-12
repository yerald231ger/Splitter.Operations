using Splitter.Extensions.Interface.Abstractions;
using Splitter.Commensality.Constants;
using Splitter.Commensality.Interface;
using Splitter.Commensality.Models;

namespace Splitter.Commensality.WebApi;

public static class VoucherRoutes
{
    public static void MapVoucherRoutes(this IEndpointRouteBuilder app)
    {
        var routeGroup = app.MapGroup("/voucher");

        routeGroup.MapGet("/", async (Guid? commandId, Guid? id, DateTime? from, DateTime? to, VoucherService orderService, bool withProducts = false, bool withVouchers = false) =>
        {
            var command = new GetVoucherCommand(commandId, id, from, to);
            var result = await orderService.GetvouchersAsync(command);
            return result switch
            {
                SptGetManyCompletion<Voucher> r => Results.Ok(r.ToDto()),
                SptRejection<CommensalityRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetVouchersDto>()
        .Produces<SptRejection<CommensalityRejectCodes>>(400)
        .WithOpenApi();


    }
}
