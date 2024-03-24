using System.Net.Http.Json;
using System.Text.Json;
using NJsonSchema;

namespace Splitter.BCMenu.IntegrationsTests;

[TestClass]
public class MenuApiTests
{
    private BCMenuWebApplicationFactory? _factory;

    [TestInitialize]
    public void Initialize()
    {
        _factory = new BCMenuWebApplicationFactory();
    }

    [TestMethod]
    public async Task Get_MenuWithLayout()
    {
        var client = _factory!.CreateClient();

        var json = await client.GetFromJsonAsync<JsonDocument>("menu/11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d");
        var layout = json!.RootElement.GetProperty("layout");

        var schema = JsonSchema.FromFileAsync("MenuLayout.schema.json").Result;
        var jsonBuilded = JsonSerializer.Serialize(layout);
        var errors = schema.Validate(jsonBuilded) ?? [];

        if (errors.Count > 0)
            Assert.Fail();
    }

     [TestMethod]
    public async Task Get_MenuWithLayoutAndImageForEachProduct()
    {
        var client = _factory!.CreateClient();

        var json = await client.GetFromJsonAsync<JsonDocument>("menu/11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d");
        var layout = json!.RootElement.GetProperty("layout");

        var schema = JsonSchema.FromFileAsync("MenuLayoutWithImages.schema.json").Result;
        var jsonBuilded = JsonSerializer.Serialize(layout);
        var errors = schema.Validate(jsonBuilded) ?? [];

        if (errors.Count > 0)
            Assert.Fail();
    }

}