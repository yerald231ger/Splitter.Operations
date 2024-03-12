using System.Text.Json;
using Splitter.Extensions.Interface.Abstractions;

namespace Splitter.BCMenu.Interface;

public class CreateLayoutCommand(Guid commandId, Guid layoutId, Guid menuId, string LayoutName, JsonDocument layout) : SptCommand(commandId)
{
    public Guid MenuId { get; } = menuId;
    public Guid LayoutId { get; } = layoutId;
    public JsonDocument Layout { get; } = layout;
    public string LayoutName { get; } = LayoutName;
}
