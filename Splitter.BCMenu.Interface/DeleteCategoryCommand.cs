using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class DeleteCategoryCommand(Guid commandId, Guid categoryId, Guid menuId) : SptCommand(commandId)
{
    public Guid CategoryId { get; set; } = categoryId;
    public Guid MenuId { get; set; } = menuId;
}
