using Splitter.Operations.Constants;
using Splitter.Operations.Interface;
using Splitter.Operations.Models;

namespace Splitter.Operations.WebApi;

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
                SptRejection<SptRejectCodes> r => Results.BadRequest(r),
                _ => Results.BadRequest()
            };
        })
        .Produces<GetVouchersDto>()
        .Produces<SptRejection<SptRejectCodes>>(400)
        .WithOpenApi();


    }
}
