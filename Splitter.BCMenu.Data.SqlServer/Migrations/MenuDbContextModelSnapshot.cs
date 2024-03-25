﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Splitter.BCMenu.Data.SqlServer;

#nullable disable

namespace Splitter.BCMenu.Data.SqlServer.Migrations
{
    [DbContext(typeof(MenuDbContext))]
    partial class MenuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Menu")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Splitter.BCMenu.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstablishmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Categories", "Menu");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d9d2154-54a5-4b09-b334-e1733ae3cfba"),
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Appetizers"
                        },
                        new
                        {
                            Id = new Guid("84bdf70f-c194-4fdd-abac-2e8ecc248d3b"),
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Main Courses"
                        },
                        new
                        {
                            Id = new Guid("571dd2a2-c73a-47f4-af8b-7fa689a82568"),
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Desserts"
                        },
                        new
                        {
                            Id = new Guid("0a0faa3e-5e89-4fc9-8d78-0041049de8f6"),
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Burgers"
                        });
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("Images", "Menu");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a713331e-86ea-40ff-8ee1-f5278368a14f"),
                            ObjectId = new Guid("30000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Bruschetta.webp"
                        },
                        new
                        {
                            Id = new Guid("1c79385a-e920-4527-b952-f1608b5ef7f2"),
                            ObjectId = new Guid("12000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CaesarSalad.webp"
                        },
                        new
                        {
                            Id = new Guid("caf7149b-097b-423d-bbfb-e8a8b3bb0232"),
                            ObjectId = new Guid("10000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CapreseSalad.webp"
                        },
                        new
                        {
                            Id = new Guid("e8f71df7-ebf5-4c49-b938-dd39a7e44741"),
                            ObjectId = new Guid("14000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/ChickenWings.webp"
                        },
                        new
                        {
                            Id = new Guid("bd8a6920-eb76-423d-9e7a-1a6c4f6bfb54"),
                            ObjectId = new Guid("20000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/GarlicBread.webp"
                        },
                        new
                        {
                            Id = new Guid("3ecbf688-c838-4165-b531-fd71ce1dd44a"),
                            ObjectId = new Guid("11000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Lasagna.webp"
                        },
                        new
                        {
                            Id = new Guid("c03e815f-a5c9-40b4-9b01-540f91fbc69f"),
                            ObjectId = new Guid("13000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SpaghettiCarbonara.webp"
                        },
                        new
                        {
                            Id = new Guid("3b927457-04fd-4f85-8360-409673a765d7"),
                            ObjectId = new Guid("40000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/StuffedMushrooms.webp"
                        },
                        new
                        {
                            Id = new Guid("6a654523-030d-4b6e-9d52-90f147d9c50a"),
                            ObjectId = new Guid("50000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CheeseBurger.webp"
                        },
                        new
                        {
                            Id = new Guid("5b887654-ffe3-4121-9e77-a27c4f924d54"),
                            ObjectId = new Guid("60000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/BaconAvocadoBurger.webp"
                        },
                        new
                        {
                            Id = new Guid("953d3fd9-43bb-4213-862a-6c7ae90f1fec"),
                            ObjectId = new Guid("70000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/MushroomSwissBurger.webp"
                        },
                        new
                        {
                            Id = new Guid("4bd83727-de6b-4278-86d8-ec47f7d86964"),
                            ObjectId = new Guid("80000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SpicyJalapenoBurger.webp"
                        },
                        new
                        {
                            Id = new Guid("1afcf6f5-09b5-487b-a7e6-f0dee2121971"),
                            ObjectId = new Guid("90000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/VeggieBurger.webp"
                        },
                        new
                        {
                            Id = new Guid("e7497cc1-4097-46e0-9072-36ce918fce54"),
                            ObjectId = new Guid("21000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/ChocolateMousse.webp"
                        },
                        new
                        {
                            Id = new Guid("756d025e-9f5f-4a16-9767-e8a4170cf7df"),
                            ObjectId = new Guid("22000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Tiramisu.webp"
                        },
                        new
                        {
                            Id = new Guid("2d44a43e-bf58-430f-a4d9-0d12547ca9eb"),
                            ObjectId = new Guid("23000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Cheesecake.webp"
                        },
                        new
                        {
                            Id = new Guid("24a9a461-0e4c-4b68-b0bc-d85b6a6a9c51"),
                            ObjectId = new Guid("24000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/FruitSorbet.webp"
                        },
                        new
                        {
                            Id = new Guid("31707c8d-2340-4452-b67c-92cfa075ffb8"),
                            ObjectId = new Guid("25000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/LemonMeringuePie.webp"
                        },
                        new
                        {
                            Id = new Guid("3f46a46a-3c23-4c85-9928-9f2bba2f7d88"),
                            ObjectId = new Guid("26000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Baklava.webp"
                        },
                        new
                        {
                            Id = new Guid("c103510c-6c7e-4072-9c7a-fd774e02c3b4"),
                            ObjectId = new Guid("15000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Espresso.webp"
                        },
                        new
                        {
                            Id = new Guid("701c2b17-c25d-46be-979c-6fac0b60f3ec"),
                            ObjectId = new Guid("16000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Cappuccino.webp"
                        },
                        new
                        {
                            Id = new Guid("fd625e4a-7577-4129-a39b-c9cb2847861e"),
                            ObjectId = new Guid("17000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Lemonade.webp"
                        },
                        new
                        {
                            Id = new Guid("27089bc2-ecea-4e73-b027-a0ac7260b383"),
                            ObjectId = new Guid("18000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/IcedTea.webp"
                        },
                        new
                        {
                            Id = new Guid("974005fd-aca0-4e0e-9c6e-8c879d7a31ed"),
                            ObjectId = new Guid("19000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SparklingWater.webp"
                        },
                        new
                        {
                            Id = new Guid("77570bde-8195-4a84-bdaf-d7e596202f93"),
                            ObjectId = new Guid("2a000000-0000-0000-0000-000000000000"),
                            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/HotChocolate.webp"
                        });
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EstablishmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menus", "Menu");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Description = "",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            Name = "Main Menu"
                        });
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.MenuLayout", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Layout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Layouts", "Menu");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca1988b5-f263-4ba5-8e3f-b5706fed20bc"),
                            CreatedAt = new DateTime(2024, 3, 25, 12, 22, 13, 850, DateTimeKind.Local).AddTicks(4290),
                            Layout = "[\r\n                    {\r\n                        \"title\": \"Appetizers\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"10000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"20000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"30000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"40000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ]\r\n                    },\r\n                    {\r\n                        \"title\": \"Main Courses\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"11000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"12000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"13000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"14000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ],\r\n                        \"categories\": [\r\n                        {\r\n                            \"title\": \"Burgers\",\r\n                            \"products\": [\r\n                                {\r\n                                    \"id\": \"50000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"60000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"70000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"80000000-0000-0000-0000-000000000000\"\r\n                                },\r\n                                {\r\n                                    \"id\": \"90000000-0000-0000-0000-000000000000\"\r\n                                }\r\n                            ]\r\n                        }\r\n                      ]\r\n                    },\r\n                    {\r\n                        \"title\": \"Desserts\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"21000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"22000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"23000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"24000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"25000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"26000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ]\r\n                    },\r\n                    {\r\n                        \"title\": \"Drinks\",\r\n                        \"products\": [\r\n                            {\r\n                                \"id\": \"15000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"16000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"17000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"18000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"19000000-0000-0000-0000-000000000000\"\r\n                            },\r\n                            {\r\n                                \"id\": \"2A000000-0000-0000-0000-000000000000\"\r\n                            }\r\n                        ]\r\n                    }\r\n                ]",
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d")
                        });
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EstablishmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Products", "Menu");

                    b.HasData(
                        new
                        {
                            Id = new Guid("10000000-0000-0000-0000-000000000000"),
                            Description = "Fresh sliced tomatoes and mozzarella, topped with basil, olive oil, and balsamic glaze",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Caprese Salad",
                            Price = 7.00m
                        },
                        new
                        {
                            Id = new Guid("20000000-0000-0000-0000-000000000000"),
                            Description = "Crusty bread buttered with a savory garlic spread, toasted to perfection",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Garlic Bread",
                            Price = 4.00m
                        },
                        new
                        {
                            Id = new Guid("30000000-0000-0000-0000-000000000000"),
                            Description = "Classic Italian appetizer with tomato, basil, and mozzarella on toasted bread",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Bruschetta",
                            Price = 5.00m
                        },
                        new
                        {
                            Id = new Guid("40000000-0000-0000-0000-000000000000"),
                            Description = "Mushroom caps filled with a mixture of cheeses, garlic, and breadcrumbs, baked until golden",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Stuffed Mushrooms",
                            Price = 8.50m
                        },
                        new
                        {
                            Id = new Guid("50000000-0000-0000-0000-000000000000"),
                            Description = "Juicy beef patty with cheddar cheese, lettuce, tomato, and our special sauce on a toasted bun",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Classic Cheeseburger",
                            Price = 8.50m
                        },
                        new
                        {
                            Id = new Guid("60000000-0000-0000-0000-000000000000"),
                            Description = "Grilled beef patty topped with crispy bacon, avocado slices, and garlic aioli on a brioche bun",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Bacon Avocado Burger",
                            Price = 10.00m
                        },
                        new
                        {
                            Id = new Guid("70000000-0000-0000-0000-000000000000"),
                            Description = "Beef patty with sautéed mushrooms, melted Swiss cheese, and Dijon mustard on a sesame seed bun",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Mushroom Swiss Burger",
                            Price = 9.50m
                        },
                        new
                        {
                            Id = new Guid("80000000-0000-0000-0000-000000000000"),
                            Description = "Beef patty with jalapenos, pepper jack cheese, crispy onions, and spicy mayo on a spicy toasted bun",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Spicy Jalapeno Burger",
                            Price = 9.00m
                        },
                        new
                        {
                            Id = new Guid("90000000-0000-0000-0000-000000000000"),
                            Description = "Grilled plant-based patty with lettuce, tomato, cucumber, and yogurt sauce on a whole wheat bun",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Veggie Burger",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = new Guid("11000000-0000-0000-0000-000000000000"),
                            Description = "Layered pasta with meat, cheese, and tomato sauce",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Lasagna",
                            Price = 12.00m
                        },
                        new
                        {
                            Id = new Guid("12000000-0000-0000-0000-000000000000"),
                            Description = "Classic Caesar salad with croutons and parmesan cheese",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Caesar Salad",
                            Price = 7.00m
                        },
                        new
                        {
                            Id = new Guid("13000000-0000-0000-0000-000000000000"),
                            Description = "Spaghetti with creamy egg sauce, pancetta, and black pepper",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Spaghetti Carbonara",
                            Price = 11.00m
                        },
                        new
                        {
                            Id = new Guid("14000000-0000-0000-0000-000000000000"),
                            Description = "Spicy glazed chicken wings with a side of blue cheese dip",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Chicken Wings",
                            Price = 9.00m
                        },
                        new
                        {
                            Id = new Guid("15000000-0000-0000-0000-000000000000"),
                            Description = "Strong and richly flavored concentrated coffee",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Espresso",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("16000000-0000-0000-0000-000000000000"),
                            Description = "A classic Italian coffee drink with espresso, hot milk, and steamed-milk foam",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Cappuccino",
                            Price = 3.00m
                        },
                        new
                        {
                            Id = new Guid("17000000-0000-0000-0000-000000000000"),
                            Description = "Refreshing drink made from lemon juice, water, and sugar",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Lemonade",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("18000000-0000-0000-0000-000000000000"),
                            Description = "Cold tea served with ice, and often with a slice of lemon",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Iced Tea",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("19000000-0000-0000-0000-000000000000"),
                            Description = "Carbonated water served chilled, perfect as a palate cleanser or refreshing drink",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Sparkling Water",
                            Price = 1.50m
                        },
                        new
                        {
                            Id = new Guid("2a000000-0000-0000-0000-000000000000"),
                            Description = "Rich chocolate drink made with milk, cocoa, and sugar, topped with whipped cream",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Hot Chocolate",
                            Price = 3.00m
                        },
                        new
                        {
                            Id = new Guid("21000000-0000-0000-0000-000000000000"),
                            Description = "Rich and airy chocolate mousse, made with high-quality dark chocolate and served with whipped cream",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Chocolate Mousse",
                            Price = 4.75m
                        },
                        new
                        {
                            Id = new Guid("22000000-0000-0000-0000-000000000000"),
                            Description = "Coffee-flavored Italian dessert with mascarpone cheese",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Tiramisu",
                            Price = 6.50m
                        },
                        new
                        {
                            Id = new Guid("23000000-0000-0000-0000-000000000000"),
                            Description = "Creamy cheesecake on a graham cracker crust, served with a choice of strawberry, blueberry, or raspberry topping",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Cheesecake",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = new Guid("24000000-0000-0000-0000-000000000000"),
                            Description = "Refreshing sorbet made from pureed fruits and served in a natural fruit shell",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Fruit Sorbet",
                            Price = 3.50m
                        },
                        new
                        {
                            Id = new Guid("25000000-0000-0000-0000-000000000000"),
                            Description = "Tart lemon custard filling with a fluffy meringue topping, served on a crisp pastry base",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Lemon Meringue Pie",
                            Price = 5.25m
                        },
                        new
                        {
                            Id = new Guid("26000000-0000-0000-0000-000000000000"),
                            Description = "Rich, sweet pastry made of layers of filo filled with chopped nuts and sweetened with syrup or honey",
                            EstablishmentId = new Guid("dd0bc94a-9da3-4695-9c0a-de2c057d2468"),
                            IsActive = false,
                            MenuId = new Guid("11000000-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                            Name = "Baklava",
                            Price = 4.00m
                        });
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Category", b =>
                {
                    b.HasOne("Splitter.BCMenu.Models.Menu", "Menu")
                        .WithMany("Categories")
                        .HasForeignKey("MenuId");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Image", b =>
                {
                    b.HasOne("Splitter.BCMenu.Models.Category", null)
                        .WithMany("Images")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Splitter.BCMenu.Models.Product", null)
                        .WithMany("Images")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.MenuLayout", b =>
                {
                    b.HasOne("Splitter.BCMenu.Models.Menu", "Menu")
                        .WithMany("MenuLayouts")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Product", b =>
                {
                    b.HasOne("Splitter.BCMenu.Models.Menu", "Menu")
                        .WithMany("Products")
                        .HasForeignKey("MenuId");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Category", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Menu", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("MenuLayouts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Splitter.BCMenu.Models.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
