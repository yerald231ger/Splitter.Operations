using System.Text.Json;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.DomainTests;

[TestClass]
public class LayoutBuilder
{
    private readonly string _json = "[{\"title\":\"Hamburguesas\",\"products\":[\"45c4768c-8140-406a-85aa-e55f741f3d87\",\"ba0766ae-d693-4d9d-bc3e-910062f7a687\",\"7d13d62e-8dfd-4f42-9acc-46ac963a286c\"]},{\"title\":\"Pizzas\",\"categories\":[{\"title\":\"Pizzas de carne\",\"products\":[\"5d3b7eab-9eb8-4a76-97dc-b286c25fcaf1\",\"8c298f3a-f617-40ed-97f9-4c0047e5a115\"]},{\"title\":\"Pizzas de pollo\",\"products\":[\"cdce0ee4-6792-4e1f-9429-0ca4ad0923bd\",\"26551d77-a11d-4f9a-a16c-95ade22c3b74\"]}]}]";

    [TestMethod]
    public void BuildLayoutProduceNotNull()
    {
        //Arrange
        var menuId = Guid.NewGuid();
        var establishmentId = Guid.NewGuid();
        var layoutId = Guid.NewGuid();
        var menu = Menu.Create(menuId, establishmentId, "Menu 1", true);
        var layout = MenuLayout.Create(layoutId, menuId, JsonDocument.Parse(_json), "Layout 1");

        menu.AddLayout(layout);

        var productId1 = Guid.Parse("45c4768c-8140-406a-85aa-e55f741f3d87");
        var productId2 = Guid.Parse("ba0766ae-d693-4d9d-bc3e-910062f7a687");
        var productId3 = Guid.Parse("7d13d62e-8dfd-4f42-9acc-46ac963a286c");
        var productId4 = Guid.Parse("5d3b7eab-9eb8-4a76-97dc-b286c25fcaf1");
        var productId5 = Guid.Parse("8c298f3a-f617-40ed-97f9-4c0047e5a115");
        var productId6 = Guid.Parse("cdce0ee4-6792-4e1f-9429-0ca4ad0923bd");
        var productId7 = Guid.Parse("26551d77-a11d-4f9a-a16c-95ade22c3b74");

        menu.AddOrCreateProduct(productId1, establishmentId, "Hamburguesa con pollo", 180.50m);
        menu.AddOrCreateProduct(productId2, establishmentId, "Hamburguesa de res", 130);
        menu.AddOrCreateProduct(productId3, establishmentId, "Hamburguesa vegetariana", 120.00m);
        menu.AddOrCreateProduct(productId4, establishmentId, "Pizza napolitana", 99.99m);
        menu.AddOrCreateProduct(productId5, establishmentId, "Pizza doble queso", 230.50m);
        menu.AddOrCreateProduct(productId6, establishmentId, "Pizza Hawuaiana", 102.00m);
        menu.AddOrCreateProduct(productId7, establishmentId, "Pizza de carnes", 123.99m);

        //Act
        menu.BuildLayoutToDisplay();

        //Assert
        Assert.IsNotNull(menu.Layout);
    }


}