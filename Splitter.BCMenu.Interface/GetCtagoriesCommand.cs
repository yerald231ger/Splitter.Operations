using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class GetCategoriesCommand(Guid commandId, Guid menuId) : SptCommand(commandId)
{
    public Guid MenuId { get; set; } = menuId;
}