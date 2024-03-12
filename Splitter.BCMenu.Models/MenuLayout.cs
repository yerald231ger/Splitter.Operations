using System.Text.Json;

namespace Splitter.BCMenu.Models;

public class MenuLayout
{
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public JsonDocument? Layout { get; set; } 
    public string? Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Menu? Menu { get; set; }

    public static MenuLayout Create(Guid layoutId, Guid menuId, JsonDocument layout, string name) => new()
    {
        Id = layoutId,
        MenuId = menuId,
        Layout = layout,
        Name = name
    };
}