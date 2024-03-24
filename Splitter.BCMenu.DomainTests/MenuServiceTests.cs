using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Splitter.BCMenu.Constants;
using Splitter.BCMenu.Interface;
using Splitter.BCMenu.Models;
using Splitter.Commensality.Data.SqlServer;
using Splitter.Extensions;
using Splitter.Extensions.Interface.Abstractions;
using NJsonSchema;

namespace Splitter.BCMenu.DomainTests;

[TestClass]
public class MenuServiceTests
{
    private readonly Lazy<ServiceProvider> _serviceProvider = new(() =>
    {
        var _services = new ServiceCollection();

        _services.AddCommandBuilder();
        _services
            .AddMenu()
                .AddData()
                    .AddInMemory();

        return _services.BuildServiceProvider();
    });

    [TestMethod]
    public async Task CreateAndReturnTheSameMenu()
    {
        //Arrange
        var menuService = _serviceProvider.Value!.GetRequiredService<MenuService>();
        var commandId = Guid.NewGuid();
        var menuId = Guid.NewGuid();
        var establishmentId = Guid.NewGuid();

        //Act
        var createMenuCommnad = new CreateMenuCommand(commandId, menuId, establishmentId, "My first menu");
        var menuCreated = await menuService.CreateMenu(createMenuCommnad) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var getMenuCommand = new GetMenuCommand(commandId, menuId);
        var menu = await menuService.GetCompleteMenu(getMenuCommand) switch
        {
            SptGetCompletion<Menu> r => r.Item,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu get failed"),
            _ => throw new Exception("Menu get failed")
        };

        //Assert
        Assert.AreEqual(menuCreated!.Id, menu!.Id);
        Assert.AreEqual(menuCreated!.Name, menu!.Name);
    }

    [TestMethod]
    public async Task CreateMenuWithTwoProductsAndReturnTheSameMenu()
    {
        //Arrange
        var menuService = _serviceProvider.Value!.GetRequiredService<MenuService>();
        var commandId = Guid.NewGuid();
        var menuId = Guid.NewGuid();
        var establishmentId = Guid.NewGuid();
        var productId1 = Guid.NewGuid();
        var productId2 = Guid.NewGuid();

        //Act
        var createMenuCommnad = new CreateMenuCommand(commandId, menuId, establishmentId, "My first menu");
        var menuCreated = await menuService.CreateMenu(createMenuCommnad) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var addProductCommand1 = new AddOrCreateProductCommand(commandId, establishmentId, menuId, productId1, "Product 1", 10);
        var product1 = await menuService.AddOrCreateProduct(addProductCommand1) switch
        {
            SptCreateCompletion<Product> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 1 creation failed"),
            _ => throw new Exception("Product 1 creation failed")
        };

        var addProductCommand2 = new AddOrCreateProductCommand(commandId, establishmentId, menuId, productId2, "Product 2", 20);
        var product2 = await menuService.AddOrCreateProduct(addProductCommand2) switch
        {
            SptCreateCompletion<Product> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 2 creation failed"),
            _ => throw new Exception("Product 2 creation failed")
        };

        var getMenuCommand = new GetMenuCommand(commandId, menuId);
        var menu = await menuService.GetCompleteMenu(getMenuCommand) switch
        {
            SptGetCompletion<Menu> r => r.Item,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu get failed"),
            _ => throw new Exception("Menu get failed")
        };

        //Assert
        Assert.AreEqual(menuCreated!.Id, menu!.Id);
        Assert.AreEqual(menuCreated!.Name, menu!.Name);
        Assert.AreEqual(2, menu!.Products.Count);
        Assert.AreEqual(product1!.Id, menu!.Products[0].Id);
        Assert.AreEqual(product1!.Name, menu!.Products[0].Name);
        Assert.AreEqual(product1!.Price, menu!.Products[0].Price);
        Assert.AreEqual(product2!.Id, menu!.Products[1].Id);
        Assert.AreEqual(product2!.Name, menu!.Products[1].Name);
        Assert.AreEqual(product2!.Price, menu!.Products[1].Price);
    }

    [TestMethod]
    public async Task CreateMenuWithTwoProductsAndRemoveOne()
    {
        //Arrange
        var menuService = _serviceProvider.Value!.GetRequiredService<MenuService>();
        var commandId = Guid.NewGuid();
        var menuId = Guid.NewGuid();
        var establishmentId = Guid.NewGuid();
        var productId1 = Guid.NewGuid();
        var productId2 = Guid.NewGuid();

        //Act
        var createMenuCommnad = new CreateMenuCommand(commandId, menuId, establishmentId, "My first menu");
        var menuCreated = await menuService.CreateMenu(createMenuCommnad) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var addProductCommand1 = new AddOrCreateProductCommand(commandId, establishmentId, menuId, productId1, "Product 1", 10);
        var product1 = await menuService.AddOrCreateProduct(addProductCommand1) switch
        {
            SptCreateCompletion<Product> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 1 creation failed"),
            _ => throw new Exception("Product 1 creation failed")
        };

        var addProductCommand2 = new AddOrCreateProductCommand(commandId, establishmentId, menuId, productId2, "Product 2", 20);
        var product2 = await menuService.AddOrCreateProduct(addProductCommand2) switch
        {
            SptCreateCompletion<Product> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 2 creation failed"),
            _ => throw new Exception("Product 2 creation failed")
        };

        var removeProductCommand = new DeleteProductCommand(commandId, menuId, productId2);
        var productRemoved = await menuService.RemoveProduct(removeProductCommand) switch
        {
            SptUpdateCompletion<Product> r => r.Updated,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 2 removal failed"),
            _ => throw new Exception("Product 2 removal failed")
        };

        var getProductsCommand = new GetProductsCommand(commandId, menuId);
        var products = await menuService.GetProducts(getProductsCommand) switch
        {
            SptGetManyCompletion<Product> r => r.Items,
            SptRejection<MenuRejectCodes> => throw new Exception("Product get failed"),
            _ => throw new Exception("Product get failed"),
        };

        //Assert
        Assert.IsTrue(products.Exists(p => p.Id == productId1));
        Assert.IsFalse(products.Exists(p => p.Id == productId2));
    }

    [TestMethod]
    public async Task CreateMenuWithTwoProductsAndModifyOne()
    {
        //Arrange
        var menuService = _serviceProvider.Value!.GetRequiredService<MenuService>();
        var commandId = Guid.NewGuid();
        var menuId = Guid.NewGuid();
        var establishmentId = Guid.NewGuid();
        var productId1 = Guid.NewGuid();
        var productId2 = Guid.NewGuid();

        //Act
        var createMenuCommnad = new CreateMenuCommand(commandId, menuId, establishmentId, "My first menu");
        var menuCreated = await menuService.CreateMenu(createMenuCommnad) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var addProductCommand1 = new AddOrCreateProductCommand(commandId, establishmentId, menuId, productId1, "Product 1", 10);
        var product1 = await menuService.AddOrCreateProduct(addProductCommand1) switch
        {
            SptCreateCompletion<Product> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 1 creation failed"),
            _ => throw new Exception("Product 1 creation failed")
        };

        var addProductCommand2 = new AddOrCreateProductCommand(commandId, establishmentId, menuId, productId2, "Product 2", 20);
        var product2 = await menuService.AddOrCreateProduct(addProductCommand2) switch
        {
            SptCreateCompletion<Product> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 2 creation failed"),
            _ => throw new Exception("Product 2 creation failed")
        };

        var modifyProductCommand = new UpdateProductCommand(commandId, menuId, productId1, "Product 1 modified", 15, "Product 1 modified description");
        var productModified = await menuService.UpdateProduct(modifyProductCommand) switch
        {
            SptUpdateCompletion<Menu> r => r.Updated,
            SptRejection<MenuRejectCodes> => throw new Exception("Product 1 modification failed"),
            _ => throw new Exception("Product 1 modification failed")
        };

        var getProductsCommand = new GetProductsCommand(commandId, menuId);
        var products = await menuService.GetProducts(getProductsCommand) switch
        {
            SptGetManyCompletion<Product> r => r.Items,
            SptRejection<MenuRejectCodes> => throw new Exception("Product get failed"),
            _ => throw new Exception("Product get failed"),
        };

        //Assert
        Assert.IsTrue(products.Exists(p => p.Id == productId1));
        Assert.IsTrue(products.Exists(p => p.Name == "Product 1 modified"));
        Assert.IsTrue(products.Exists(p => p.Price == 15));
        Assert.IsTrue(products.Exists(p => p.Description == "Product 1 modified description"));

    }

    [TestMethod]
    public async Task CreateMenuWithTwoCategoryAndGetTheSame()
    {
        //Arrange
        var menuService = _serviceProvider.Value!.GetRequiredService<MenuService>();
        var commandId = Guid.NewGuid();
        var menuId = Guid.NewGuid();
        var establishmentId = Guid.NewGuid();
        var categoryId1 = Guid.NewGuid();
        var categoryId2 = Guid.NewGuid();

        //Act
        var createMenuCommnad = new CreateMenuCommand(commandId, menuId, establishmentId, "My first menu");
        var menuCreated = await menuService.CreateMenu(createMenuCommnad) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var addCategoryCommand1 = new AddOrCreateCategoryCommand(commandId, establishmentId, categoryId1, menuId, "Category 1");
        var category1 = await menuService.AddOrCreateCategory(addCategoryCommand1) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Category 1 creation failed"),
            _ => throw new Exception("Category 1 creation failed")
        };

        var addCategoryCommand2 = new AddOrCreateCategoryCommand(commandId, establishmentId, categoryId2, menuId, "Category 2");
        var category2 = await menuService.AddOrCreateCategory(addCategoryCommand2) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Category 2 creation failed"),
            _ => throw new Exception("Category 2 creation failed")
        };

        var getCategoriesCommand = new GetCategoriesCommand(commandId, menuId);
        var categories = await menuService.GetCategories(getCategoriesCommand) switch
        {
            SptGetManyCompletion<Category> r => r.Items,
            SptRejection<MenuRejectCodes> => throw new Exception("Category get failed"),
            _ => throw new Exception("Category get failed"),
        };

        //Assert
        Assert.AreEqual(2, categories.Count);
        Assert.IsTrue(categories.Exists(c => c.Id == categoryId1));
        Assert.IsTrue(categories.Exists(c => c.Name == "Category 1"));
        Assert.IsTrue(categories.Exists(c => c.Id == categoryId2));
        Assert.IsTrue(categories.Exists(c => c.Name == "Category 2"));
    }

    [TestMethod]
    public async Task CreateLayoutToDisplayAndValidAgainstJsonSchema()
    {
        //Arrange
        var menuService = _serviceProvider.Value!.GetRequiredService<MenuService>();
        var commandId = Guid.NewGuid();
        var menuId = Guid.NewGuid();
        var layoutId = Guid.NewGuid();
        var establishmentId = Guid.NewGuid();
        var categoryHamburegusaGuid = Guid.Parse("10c4768c-8140-406a-85aa-e55f741f3d00");
        var categoryPizzaCarneGuid = Guid.Parse("ca0766ae-d693-4d9d-bc3e-910062f7a681");
        var categoryPizzaPolloGuid = Guid.Parse("ad13d62e-8dfd-4f42-9acc-46ac963a2862");
        var hamburguesaChicaGuid = Guid.Parse("45c4768c-8140-406a-85aa-e55f741f3d87");
        var hamburguesaMedianaGuid = Guid.Parse("ba0766ae-d693-4d9d-bc3e-910062f7a687");
        var hamburgueraGardeGuid = Guid.Parse("7d13d62e-8dfd-4f42-9acc-46ac963a286c");
        var pizzaCarneChicaGuid = Guid.Parse("5d3b7eab-9eb8-4a76-97dc-b286c25fcaf1");
        var pizzaCarneGrandeGuid = Guid.Parse("8c298f3a-f617-40ed-97f9-4c0047e5a115");
        var pizzaPolloChicaGuid = Guid.Parse("cdce0ee4-6792-4e1f-9429-0ca4ad0923bd");
        var pizzaPolloGrandeGuid = Guid.Parse("26551d77-0000-4f9a-a16c-95ade22c3b74");
        var json = JsonDocument.Parse(File.ReadAllText("MenuLayout.json"));

        var createMenuCommnad = new CreateMenuCommand(commandId, menuId, establishmentId, "My first menu");
        var menuCreated = await menuService.CreateMenu(createMenuCommnad) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var addProducthamburguesaChicaCommand = new AddOrCreateProductCommand(commandId, establishmentId, menuId, hamburguesaChicaGuid, "Hamburgueza chica", 10);
        var hamburguesaChica = GetResultProduct(await menuService.AddOrCreateProduct(addProducthamburguesaChicaCommand));

        var addProducthamburguesaMedianaCommand = new AddOrCreateProductCommand(commandId, establishmentId, menuId, hamburguesaMedianaGuid, "Hamburgueza mediana", 20);
        var hamburguesaMediana = GetResultProduct(await menuService.AddOrCreateProduct(addProducthamburguesaMedianaCommand));

        var addProductHamburguesaGrandeCommand = new AddOrCreateProductCommand(commandId, establishmentId, menuId, hamburgueraGardeGuid, "Hambuergueza grande", 20);
        var hamburgueraGarde = GetResultProduct(await menuService.AddOrCreateProduct(addProductHamburguesaGrandeCommand));

        var addProductPizzaCarneChicaCommand = new AddOrCreateProductCommand(commandId, establishmentId, menuId, pizzaCarneChicaGuid, "Pizza Carne chica", 20);
        var pizzaCarneChica = GetResultProduct(await menuService.AddOrCreateProduct(addProductPizzaCarneChicaCommand));

        var addProductPizzaCarneGrandeCommand = new AddOrCreateProductCommand(commandId, establishmentId, menuId, pizzaCarneGrandeGuid, "Pizza Carne grande", 20);
        var pizzaCarneGrande = GetResultProduct(await menuService.AddOrCreateProduct(addProductPizzaCarneGrandeCommand));

        var addProductPizzaPolloChicaCommand = new AddOrCreateProductCommand(commandId, establishmentId, menuId, pizzaPolloChicaGuid, "Pizza Pollo chica", 20);
        var pizzaPolloChica = GetResultProduct(await menuService.AddOrCreateProduct(addProductPizzaPolloChicaCommand));

        var addProductPizzaPolloGrandeCommand = new AddOrCreateProductCommand(commandId, establishmentId, menuId, pizzaPolloGrandeGuid, "Pizza Pollo grande", 20);
        var pizzaPolloGrande = GetResultProduct(await menuService.AddOrCreateProduct(addProductPizzaPolloGrandeCommand));


        var addCategoryHamburguesasCommand = new AddOrCreateCategoryCommand(commandId, establishmentId, categoryHamburegusaGuid, menuId, "Hamburguesas");
        var categoryHamburguesas = GetResultCategory(await menuService.AddOrCreateCategory(addCategoryHamburguesasCommand));

        var addCategoryPizzaCarneCommand = new AddOrCreateCategoryCommand(commandId, establishmentId, categoryPizzaCarneGuid, menuId, "Pizza Carne");
        var categoryPizzaCarne = GetResultCategory(await menuService.AddOrCreateCategory(addCategoryPizzaCarneCommand));

        var addCategoryPizzaPolloCommand = new AddOrCreateCategoryCommand(commandId, establishmentId, categoryPizzaPolloGuid, menuId, "Pizza Pollo");
        var categoryPizzaPollo = GetResultCategory(await menuService.AddOrCreateCategory(addCategoryPizzaPolloCommand));


        var addLayoutCommand = new CreateLayoutCommand(commandId, layoutId, menuId, "My first layout", json);
        var layoutCreated = await menuService.CreateLayout(addLayoutCommand) switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var getMenuCommand = new GetMenuCommand(commandId, menuId);
        var menu = await menuService.GetCompleteMenu(getMenuCommand) switch
        {
            SptGetCompletion<Menu> r => r.Item,
            SptRejection<MenuRejectCodes> => throw new Exception("Menu creation failed"),
            _ => throw new Exception("Menu creation failed")
        };

        var schema = JsonSchema.FromFileAsync("MenuLayout.schema.json").Result;
        var jsonBuilded = JsonSerializer.Serialize(layoutCreated!.Layout);
        var errors = schema.Validate(jsonBuilded) ?? [];

        if (errors.Count > 0)
            Assert.Fail();
    }

    private static Product? GetResultProduct(SptResult result)
    {
        return result switch
        {
            SptCreateCompletion<Product> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception(),
            _ => throw new Exception()
        };
    }
    private static Menu? GetResultCategory(SptResult result)
    {
        return result switch
        {
            SptCreateCompletion<Menu> r => r.Created,
            SptRejection<MenuRejectCodes> => throw new Exception(),
            _ => throw new Exception()
        };
    }
}
