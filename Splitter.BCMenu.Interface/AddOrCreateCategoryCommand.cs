using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class AddOrCreateCategoryCommand(Guid commandId, Guid establishmentId, Guid categoryId, Guid menuId, string categoryName) : SptCommand(commandId)
{
    public Guid CategoryId { get; set; } = categoryId;
    public Guid EstablishmentId { get; set; } = establishmentId;
    public Guid MenuId { get; set; } = menuId;
    public string CategoryName { get; set; } = categoryName;
}
