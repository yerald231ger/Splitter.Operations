using Splitter.BCMenu.Models;
using Splitter.Extensions;

namespace Splitter.BCMenu.WebApi;

public record MenuDto : ReponseDto
{
    public required Guid Id { get; set; }
    public required Guid EstablishmentId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<ScaffoldCategory> Layout { get; set; } = [];

    public List<ProductDto> Products { get; set; } = [];
}
