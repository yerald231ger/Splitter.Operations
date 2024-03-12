using System.Text.Json.Serialization;

namespace Splitter.BCMenu.Models;

public class ScaffoldCategory<TProduct>
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("products")]
    public List<TProduct> Products { get; set; } = [];
    [JsonPropertyName("categories")]
    public List<ScaffoldCategory<TProduct>> Categories { get; set; } = [];
}

public class ScaffoldProduct
{
    [JsonPropertyName("id")]
    public required Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("images")]
    public string[] Images { get; set; } = [];

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}