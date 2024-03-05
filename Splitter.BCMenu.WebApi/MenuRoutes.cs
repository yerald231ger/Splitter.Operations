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
        var routeGroup = app.MapGroup("/menu");

        // Get a Menu
        routeGroup.MapGet("/{menuId}", async (Guid menuId, MenuService menuServices) =>
        {
            var command = new GetMenuCommand(Guid.NewGuid(), menuId);
            var result = await menuServices.GetMenu(command);

            return result switch
            {
                SptGetCompletion<Menu> r => Results.Ok(r.ToDto()),
                SptRejection<MenuRejectCodes> => Results.NotFound(result),
                _ => Results.StatusCode(500)
            };
        })
        .Produces(200, responseType: typeof(MenuDto))
        .Produces(404, responseType: typeof(SptRejection<MenuRejectCodes>))
        .Produces(500);

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

        // Add or Create a Product
        routeGroup.MapPost("/{menuId}/product", async (Guid menuId, CreateProductDto dto, MenuService menuServices) =>
        {
            var command = new AddOrCreateProductCommand(dto.CommandId, establishmentId, menuId, dto.ProductId, dto.ProductName, dto.ProductPrice);
            var result = await menuServices.AddOrCreateProduct(command);

            return result switch
            {
                SptCreateCompletion<Product> r => Results.Created($"/{r.Created!.Id}", r.ToDto()),
                SptRejection<MenuRejectCodes> => Results.BadRequest(result),
                _ => Results.StatusCode(500)
            };
        })
        .Produces(201, responseType: typeof(MenuDto))
        .Produces(400, responseType: typeof(SptRejection<MenuRejectCodes>))
        .Produces(500);

        // Remove a Product
        routeGroup.MapDelete("/{menuId}/product/{productId}", async (Guid menuId, Guid productId, MenuService menuServices) =>
        {
            var command = new DeleteProductCommand(Guid.NewGuid(), menuId, productId);
            var result = await menuServices.RemoveProduct(command);

            return result switch
            {
                SptCreateCompletion<Product> r => Results.NoContent(),
                SptRejection<MenuRejectCodes> => Results.BadRequest(result),
                _ => Results.StatusCode(500)
            };
        })
        .Produces(204)
        .Produces(400, responseType: typeof(SptRejection<MenuRejectCodes>))
        .Produces(500);
    }
}
