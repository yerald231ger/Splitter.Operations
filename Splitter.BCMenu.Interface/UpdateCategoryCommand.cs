using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class UpdateCategoryCommand(Guid commandId, Guid menuId, Guid categoryId, string categoryName, bool isActive) : SptCommand(commandId)
{
    public Guid CategoryId { get; set; } = categoryId;
    public Guid MenuId { get; set; } = menuId;
    public string CategoryName { get; set; } = categoryName;
    public bool IsActive { get; set; } = isActive;
}