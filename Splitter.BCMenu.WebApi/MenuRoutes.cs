using Splitter.BCMenu.Constants;
using Splitter.BCMenu.Interface;
using Splitter.BCMenu.Models;
using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.WebApi;

public static class MenuRoutes
{
    private static readonly Guid establishmentId = Guid.Parse("97ce50e6-508d-479e-a41d-b6ccfe604bf2");
    public static void MapMenuRoutes(this WebApplication app)
    {
        var routeGroup = app.MapGroup("/commensality");

        // Create a new Menu
        routeGroup.MapPost("/", async (CreateMenuDto dto, MenuService menuServices) =>
        {
            var command = new CreateMenuCommand(dto.CommandId, dto.MenuId, establishmentId, dto.MenuName);
            var result = await menuServices.CreateMenu(command);

            return result switch
            {
                SptCreateCompletion<Menu> r => Results.Created($"/{r.Created!.Id}", r.ToDto()),
                SptRejection<MenuRejectCodes> => Results.BadRequest(result),
                _ => Results.StatusCode(500)
            };

        })
        .Produces(201, responseType: typeof(MenuDto))
        .Produces(400, responseType: typeof(SptRejection<MenuRejectCodes>))
        .Produces(500)
        .WithOpenApi();
    }
}
