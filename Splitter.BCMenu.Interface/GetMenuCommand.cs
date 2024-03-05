using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class GetMenuCommand(Guid commandId, Guid menuId) : SptCommand(commandId)
{
    public Guid MenuId { get; } = menuId;
}