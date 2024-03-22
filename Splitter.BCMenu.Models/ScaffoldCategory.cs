using System.Text.Json.Serialization;

namespace Splitter.BCMenu.Models;

public class ScaffoldCategory
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("products")]
    public List<ScaffoldProduct> Products { get; set; } = [];
    [JsonPropertyName("categories")]
    public List<ScaffoldCategory> Categories { get; set; } = [];
}

public class ScaffoldProduct
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public decimal Price { get; set; } = -1;

    [JsonPropertyName("images")]
    public string[] Images { get; set; } = [];

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}