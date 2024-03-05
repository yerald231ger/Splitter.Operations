using Splitter.Extensions;

namespace Splitter.BCMenu.WebApi;

public record CreateMenuDto : RequestDto
{
    public Guid MenuId { get; set; }
    public required string MenuName { get; set; }
}
