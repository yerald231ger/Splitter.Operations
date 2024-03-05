using System.Text.Json;
using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class CreateLayoutCommand(Guid commandId, Guid layoutId, Guid menuId, string LayoutName, JsonElement layout) : SptCommand(commandId)
{
    public Guid MenuId { get; } = menuId;
    public Guid LayoutId { get; } = layoutId;
    public JsonElement Layout { get; } = layout;
    public string LayoutName { get; } = LayoutName;
}
