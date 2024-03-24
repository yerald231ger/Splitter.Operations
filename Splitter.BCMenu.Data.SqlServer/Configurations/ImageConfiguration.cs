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
            ObjectId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
            Url = "https://splitterdevstoreacc.blob.core.windows.net/menuimages/CaesarSalad.webp"
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
        }
    ];
}