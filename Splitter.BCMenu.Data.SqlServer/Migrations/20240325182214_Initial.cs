using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Splitter.BCMenu.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Menu");

            migrationBuilder.CreateTable(
                name: "Menus",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "Menu",
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Layouts",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Layouts_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "Menu",
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Menus_MenuId",
                        column: x => x.MenuId,
                        principalSchema: "Menu",
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Menu",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Menu",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "Images",
                columns: new[] { "Id", "CategoryId", "ObjectId", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("1afcf6f5-09b5-487b-a7e6-f0dee2121971"), null, new Guid("90000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/VeggieBurger.webp" },
                    { new Guid("1c79385a-e920-4527-b952-f1608b5ef7f2"), null, new Guid("12000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CaesarSalad.webp" },
                    { new Guid("24a9a461-0e4c-4b68-b0bc-d85b6a6a9c51"), null, new Guid("24000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/FruitSorbet.webp" },
                    { new Guid("27089bc2-ecea-4e73-b027-a0ac7260b383"), null, new Guid("18000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/IcedTea.webp" },
                    { new Guid("2d44a43e-bf58-430f-a4d9-0d12547ca9eb"), null, new Guid("23000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Cheesecake.webp" },
                    { new Guid("31707c8d-2340-4452-b67c-92cfa075ffb8"), null, new Guid("25000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/LemonMeringuePie.webp" },
                    { new Guid("3b927457-04fd-4f85-8360-409673a765d7"), null, new Guid("40000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/StuffedMushrooms.webp" },
                    { new Guid("3ecbf688-c838-4165-b531-fd71ce1dd44a"), null, new Guid("11000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Lasagna.webp" },
                    { new Guid("3f46a46a-3c23-4c85-9928-9f2bba2f7d88"), null, new Guid("26000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Baklava.webp" },
                    { new Guid("4bd83727-de6b-4278-86d8-ec47f7d86964"), null, new Guid("80000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SpicyJalapenoBurger.webp" },
                    { new Guid("5b887654-ffe3-4121-9e77-a27c4f924d54"), null, new Guid("60000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/BaconAvocadoBurger.webp" },
                    { new Guid("6a654523-030d-4b6e-9d52-90f147d9c50a"), null, new Guid("50000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CheeseBurger.webp" },
                    { new Guid("701c2b17-c25d-46be-979c-6fac0b60f3ec"), null, new Guid("16000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Cappuccino.webp" },
                    { new Guid("756d025e-9f5f-4a16-9767-e8a4170cf7df"), null, new Guid("22000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Tiramisu.webp" },
                    { new Guid("77570bde-8195-4a84-bdaf-d7e596202f93"), null, new Guid("2a000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/HotChocolate.webp" },
                    { new Guid("953d3fd9-43bb-4213-862a-6c7ae90f1fec"), null, new Guid("70000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/MushroomSwissBurger.webp" },
                    { new Guid("974005fd-aca0-4e0e-9c6e-8c879d7a31ed"), null, new Guid("19000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SparklingWater.webp" },
                    { new Guid("a713331e-86ea-40ff-8ee1-f5278368a14f"), null, new Guid("30000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Bruschetta.webp" },
                    { new Guid("bd8a6920-eb76-423d-9e7a-1a6c4f6bfb54"), null, new Guid("20000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/GarlicBread.webp" },
                    { new Guid("c03e815f-a5c9-40b4-9b01-540f91fbc69f"), null, new Guid("13000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SpaghettiCarbonara.webp" },
                    { new Guid("c103510c-6c7e-4072-9c7a-fd774e02c3b4"), null, new Guid("15000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Espresso.webp" },
                    { new Guid("caf7149b-097b-423d-bbfb-e8a8b3bb0232"), null, new Guid("10000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CapreseSalad.webp" },
                    { new Guid("e7497cc1-4097-46e0-9072-36ce918fce54"), null, new Guid("21000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/ChocolateMousse.webp" },
                    { new Guid("e8f71df7-ebf5-4c49-b938-dd39a7e44741"), null, new Guid("14000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/ChickenWings.webp" },
                    { new Guid("fd625e4a-7577-4129-a39b-c9cb2847861e"), null, new Guid("17000000-0000-0000-0000-000000000000"), null, "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Lemonade.webp" }
                });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "Menus",
                columns: new[] { "Id", "Description", "EstablishmentId", "IsActive", "Name" },
                values: new object[] { new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, "Main Menu" });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "Categories",
                columns: new[] { "Id", "EstablishmentId", "IsActive", "MenuId", "Name" },
                values: new object[,]
                {
                    { new Guid("0a0faa3e-5e89-4fc9-8d78-0041049de8f6"), new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Burgers" },
                    { new Guid("571dd2a2-c73a-47f4-af8b-7fa689a82568"), new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Desserts" },
                    { new Guid("84bdf70f-c194-4fdd-abac-2e8ecc248d3b"), new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Main Courses" },
                    { new Guid("8d9d2154-54a5-4b09-b334-e1733ae3cfba"), new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Appetizers" }
                });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "Layouts",
                columns: new[] { "Id", "CreatedAt", "Layout", "MenuId", "Name" },
                values: new object[] { new Guid("ca1988b5-f263-4ba5-8e3f-b5706fed20bc"), new DateTime(2024, 3, 25, 12, 22, 13, 850, DateTimeKind.Local).AddTicks(4290), "[\r\n                    {\r\n                        \"title\": \"Appetizers\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"10000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"20000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"30000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"40000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ]\r\n                    },\r\n                    {\r\n                        \"title\": \"Main Courses\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"11000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"12000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"13000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"14000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ],\r\n                        \"categories\": [\r\n                        {\r\n                            \"title\": \"Burgers\",\r\n                            \"products\": [\r\n                                {\r\n                                    \"id\": \"50000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"60000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"70000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"80000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"90000000-0000-0000-0000-000000000000\"\r\n                                }\r\n                            ]\r\n                        }\r\n                      ]\r\n                    },\r\n                    {\r\n                        \"title\": \"Desserts\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"21000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"22000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"23000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"24000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"25000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"26000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ]\r\n                    },\r\n                    {\r\n                        \"title\": \"Drinks\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"15000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"16000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"17000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"18000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"19000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"2A000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ]\r\n                    }\r\n                ]", new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), null });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "Products",
                columns: new[] { "Id", "Description", "EstablishmentId", "IsActive", "MenuId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000000"), "Fresh sliced tomatoes and mozzarella, topped with basil, olive oil, and balsamic glaze", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Caprese Salad", 7.00m },
                    { new Guid("11000000-0000-0000-0000-000000000000"), "Layered pasta with meat, cheese, and tomato sauce", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Lasagna", 12.00m },
                    { new Guid("12000000-0000-0000-0000-000000000000"), "Classic Caesar salad with croutons and parmesan cheese", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Caesar Salad", 7.00m },
                    { new Guid("13000000-0000-0000-0000-000000000000"), "Spaghetti with creamy egg sauce, pancetta, and black pepper", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Spaghetti Carbonara", 11.00m },
                    { new Guid("14000000-0000-0000-0000-000000000000"), "Spicy glazed chicken wings with a side of blue cheese dip", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Chicken Wings", 9.00m },
                    { new Guid("15000000-0000-0000-0000-000000000000"), "Strong and richly flavored concentrated coffee", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Espresso", 2.50m },
                    { new Guid("16000000-0000-0000-0000-000000000000"), "A classic Italian coffee drink with espresso, hot milk, and steamed-milk foam", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Cappuccino", 3.00m },
                    { new Guid("17000000-0000-0000-0000-000000000000"), "Refreshing drink made from lemon juice, water, and sugar", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Lemonade", 2.00m },
                    { new Guid("18000000-0000-0000-0000-000000000000"), "Cold tea served with ice, and often with a slice of lemon", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Iced Tea", 2.50m },
                    { new Guid("19000000-0000-0000-0000-000000000000"), "Carbonated water served chilled, perfect as a palate cleanser or refreshing drink", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Sparkling Water", 1.50m },
                    { new Guid("20000000-0000-0000-0000-000000000000"), "Crusty bread buttered with a savory garlic spread, toasted to perfection", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Garlic Bread", 4.00m },
                    { new Guid("21000000-0000-0000-0000-000000000000"), "Rich and airy chocolate mousse, made with high-quality dark chocolate and served with whipped cream", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Chocolate Mousse", 4.75m },
                    { new Guid("22000000-0000-0000-0000-000000000000"), "Coffee-flavored Italian dessert with mascarpone cheese", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Tiramisu", 6.50m },
                    { new Guid("23000000-0000-0000-0000-000000000000"), "Creamy cheesecake on a graham cracker crust, served with a choice of strawberry, blueberry, or raspberry topping", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Cheesecake", 6.00m },
                    { new Guid("24000000-0000-0000-0000-000000000000"), "Refreshing sorbet made from pureed fruits and served in a natural fruit shell", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Fruit Sorbet", 3.50m },
                    { new Guid("25000000-0000-0000-0000-000000000000"), "Tart lemon custard filling with a fluffy meringue topping, served on a crisp pastry base", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Lemon Meringue Pie", 5.25m },
                    { new Guid("26000000-0000-0000-0000-000000000000"), "Rich, sweet pastry made of layers of filo filled with chopped nuts and sweetened with syrup or honey", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Baklava", 4.00m },
                    { new Guid("2a000000-0000-0000-0000-000000000000"), "Rich chocolate drink made with milk, cocoa, and sugar, topped with whipped cream", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Hot Chocolate", 3.00m },
                    { new Guid("30000000-0000-0000-0000-000000000000"), "Classic Italian appetizer with tomato, basil, and mozzarella on toasted bread", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Bruschetta", 5.00m },
                    { new Guid("40000000-0000-0000-0000-000000000000"), "Mushroom caps filled with a mixture of cheeses, garlic, and breadcrumbs, baked until golden", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Stuffed Mushrooms", 8.50m },
                    { new Guid("50000000-0000-0000-0000-000000000000"), "Juicy beef patty with cheddar cheese, lettuce, tomato, and our special sauce on a toasted bun", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Classic Cheeseburger", 8.50m },
                    { new Guid("60000000-0000-0000-0000-000000000000"), "Grilled beef patty topped with crispy bacon, avocado slices, and garlic aioli on a brioche bun", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Bacon Avocado Burger", 10.00m },
                    { new Guid("70000000-0000-0000-0000-000000000000"), "Beef patty with sautéed mushrooms, melted Swiss cheese, and Dijon mustard on a sesame seed bun", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Mushroom Swiss Burger", 9.50m },
                    { new Guid("80000000-0000-0000-0000-000000000000"), "Beef patty with jalapenos, pepper jack cheese, crispy onions, and spicy mayo on a spicy toasted bun", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Spicy Jalapeno Burger", 9.00m },
                    { new Guid("90000000-0000-0000-0000-000000000000"), "Grilled plant-based patty with lettuce, tomato, cucumber, and yogurt sauce on a whole wheat bun", new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"), false, new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), "Veggie Burger", 8.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MenuId",
                schema: "Menu",
                table: "Categories",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CategoryId",
                schema: "Menu",
                table: "Images",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                schema: "Menu",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Layouts_MenuId",
                schema: "Menu",
                table: "Layouts",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MenuId",
                schema: "Menu",
                table: "Products",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Layouts",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "Menus",
                schema: "Menu");
        }
    }
}
