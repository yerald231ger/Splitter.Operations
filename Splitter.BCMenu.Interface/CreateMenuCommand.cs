using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class CreateMenuCommand(Guid commandId, Guid menuId, Guid establishmentId, string menuName) : SptCommand(commandId)
{
    public Guid MenuId { get; } = menuId;
    public Guid EstablishmentId { get; set; } = establishmentId;
    public string MenuName { get; } = menuName;
}
