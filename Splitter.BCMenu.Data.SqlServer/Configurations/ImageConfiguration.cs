using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Splitter.BCMenu.Models;

namespace Splitter.BCMenu.Data.SqlServer;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images")
        .HasKey(t => t.Id);

        builder.Property(p => p.Id)
        .ValueGeneratedNever();

        builder.HasData(images);
    }

    private readonly List<Image> images =
    [
        new Image
        {
            Id = Guid.Parse("a713331e-86ea-40ff-8ee1-f5278368a14f"),
            ObjectId = Guid.Parse("30000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Bruschetta.webp"
        },
        new Image
        {
            Id = Guid.Parse("1c79385a-e920-4527-b952-f1608b5ef7f2"),
            ObjectId = Guid.Parse("12000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CaesarSalad.webp"
        },
        new Image
        {
            Id = Guid.Parse("caf7149b-097b-423d-bbfb-e8a8b3bb0232"),
            ObjectId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CapreseSalad.webp"
        },
        new Image
        {
            Id = Guid.Parse("e8f71df7-ebf5-4c49-b938-dd39a7e44741"),
            ObjectId = Guid.Parse("14000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/ChickenWings.webp"
        },
        new Image
        {
            Id = Guid.Parse("bd8a6920-eb76-423d-9e7a-1a6c4f6bfb54"),
            ObjectId = Guid.Parse("20000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/GarlicBread.webp"
        },
        new Image
        {
            Id = Guid.Parse("3ecbf688-c838-4165-b531-fd71ce1dd44a"),
            ObjectId = Guid.Parse("11000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Lasagna.webp"
        },
        new Image
        {
            Id = Guid.Parse("c03e815f-a5c9-40b4-9b01-540f91fbc69f"),
            ObjectId = Guid.Parse("13000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SpaghettiCarbonara.webp"
        },
        new Image
        {
            Id = Guid.Parse("3b927457-04fd-4f85-8360-409673a765d7"),
            ObjectId = Guid.Parse("40000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/StuffedMushrooms.webp"
        },
        new Image
        {
            Id = Guid.Parse("6a654523-030d-4b6e-9d52-90f147d9c50a"),
            ObjectId = Guid.Parse("50000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CheeseBurger.webp"
        },
        new Image
        {
            Id = Guid.Parse("5b887654-ffe3-4121-9e77-a27c4f924d54"),
            ObjectId = Guid.Parse("60000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/BaconAvocadoBurger.webp"
        },
        new Image
        {
            Id = Guid.Parse("953d3fd9-43bb-4213-862a-6c7ae90f1fec"),
            ObjectId = Guid.Parse("70000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/MushroomSwissBurger.webp"
        },
        new Image
        {
            Id = Guid.Parse("4bd83727-de6b-4278-86d8-ec47f7d86964"),
            ObjectId = Guid.Parse("80000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SpicyJalapenoBurger.webp"
        },
        new Image
        {
            Id = Guid.Parse("1afcf6f5-09b5-487b-a7e6-f0dee2121971"),
            ObjectId = Guid.Parse("90000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/VeggieBurger.webp"
        },
        new Image
        {
            Id = Guid.Parse("e7497cc1-4097-46e0-9072-36ce918fce54"),
            ObjectId = Guid.Parse("21000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/ChocolateMousse.webp"
        },
        new Image
        {
            Id = Guid.Parse("756d025e-9f5f-4a16-9767-e8a4170cf7df"),
            ObjectId = Guid.Parse("22000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Tiramisu.webp"
        },
        new Image
        {
            Id = Guid.Parse("2d44a43e-bf58-430f-a4d9-0d12547ca9eb"),
            ObjectId = Guid.Parse("23000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Cheesecake.webp"
        },
        new Image
        {
            Id = Guid.Parse("24a9a461-0e4c-4b68-b0bc-d85b6a6a9c51"),
            ObjectId = Guid.Parse("24000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/FruitSorbet.webp"
        },
        new Image
        {
            Id = Guid.Parse("31707c8d-2340-4452-b67c-92cfa075ffb8"),
            ObjectId = Guid.Parse("25000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/LemonMeringuePie.webp"
        },
        new Image
        {
            Id = Guid.Parse("3f46a46a-3c23-4c85-9928-9f2bba2f7d88"),
            ObjectId = Guid.Parse("26000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Baklava.webp"
        },
        new Image
        {
            Id = Guid.Parse("c103510c-6c7e-4072-9c7a-fd774e02c3b4"),
            ObjectId = Guid.Parse("15000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Espresso.webp"
        },
        new Image
        {
            Id = Guid.Parse("701c2b17-c25d-46be-979c-6fac0b60f3ec"),
            ObjectId = Guid.Parse("16000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Cappuccino.webp"
        },
        new Image
        {
            Id = Guid.Parse("fd625e4a-7577-4129-a39b-c9cb2847861e"),
            ObjectId = Guid.Parse("17000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/Lemonade.webp"
        },
        new Image
        {
            Id = Guid.Parse("27089bc2-ecea-4e73-b027-a0ac7260b383"),
            ObjectId = Guid.Parse("18000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/IcedTea.webp"
        },
        new Image
        {
            Id = Guid.Parse("974005fd-aca0-4e0e-9c6e-8c879d7a31ed"),
            ObjectId = Guid.Parse("19000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/SparklingWater.webp"
        },
        new Image
        {
            Id = Guid.Parse("77570bde-8195-4a84-bdaf-d7e596202f93"),
            ObjectId = Guid.Parse("2A000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/HotChocolate.webp"
        }
    ];
}