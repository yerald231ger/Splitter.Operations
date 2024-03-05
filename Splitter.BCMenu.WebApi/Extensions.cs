using Splitter.BCMenu.Models;
using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.WebApi;

public static class Extensions
{
    public static MenuDto ToDto(this SptCreateCompletion<Menu> cmd)
    {
        return new MenuDto
        {
            CommandId = cmd.CommandId,
            Id = cmd.Created!.Id,
            EstablishmentId = cmd.Created.EstablishmentId,
            Name = cmd.Created.Name,
            Description = cmd.Created.Description,
            IsActive = cmd.Created.IsActive
        };
    }
}
