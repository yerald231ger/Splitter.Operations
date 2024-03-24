using Splitter.BCMenu.Models;
using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.WebApi;

public static class Extensions
{
    public static MenuDto ToDto(this SptCreateCompletion<Menu> cmd)
    {
        var menuDto = new MenuDto
        {
            CommandId = cmd.CommandId,
            Id = cmd.Created!.Id,
            EstablishmentId = cmd.Created.EstablishmentId,
            Name = cmd.Created.Name,
            Description = cmd.Created.Description,
            IsActive = cmd.Created.IsActive,
            Products = cmd.Created.Products.Select(p => p.ToDto()).ToList()
        };

        return menuDto;
    }

    public static MenuDto ToDto(this SptGetCompletion<Menu> cmd)
    {
        var menuDto = new MenuDto
        {
            CommandId = cmd.CommandId,
            Id = cmd.Item!.Id,
            EstablishmentId = cmd.Item.EstablishmentId,
            Name = cmd.Item.Name,
            Description = cmd.Item.Description,
            IsActive = cmd.Item.IsActive,
            Layout = cmd.Item.Layout,
        };
        return menuDto;
    }

    public static ProductDto ToDto(this SptCreateCompletion<Product> cmd)
    {
        var productDto = cmd.Created!.ToDto();
        productDto.CommandId = cmd.CommandId;
        return productDto;
    }

    public static ProductDto ToDto(this Product p)
    {
        return new ProductDto
        {
            ProductId = p.Id,
            EstablishmentId = p.EstablishmentId,
            ProductName = p.Name,
            ProductPrice = p.Price
        };
    }

}
