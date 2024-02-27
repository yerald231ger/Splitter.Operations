using System.ComponentModel;

namespace Splitter.BCMenu.Constants;

public enum MenuRejectCodes
{
    [Description("Name is required")]
    NameRequired = 1,
    [Description("Description is required")]
    DescriptionRequired = 2,
    [Description("Version is required")]
    VersionRequired = 3,
    [Description("MenuLayout is required")]
    MenuLayoutRequired = 4,
    [Description("MenuLayout is invalid")]
    MenuLayoutInvalid = 5,
    [Description("Product is required")]
    ProductRequired = 6,
    [Description("Category is required")]
    CategoryRequired = 7,
    [Description("ProductName is required")]
    ProductNameRequired = 8,
    [Description("ProductPrice is required")]
    ProductPriceRequired = 9,
    [Description("ProductDescription is required")]
    ProductDescriptionRequired = 10,
    [Description("CategoryName is required")]
    CategoryNameRequired = 11,
    [Description("RestaurantId is required")]
    RestaurantIdRequired = 12,
    [Description("ImageUrl is required")]
    ImageUrlRequired = 13,
    [Description("ImageObjectId is required")]
    ImageObjectIdRequired = 14,
    [Description("Menu not found")]
    MenuNotFound = 15,
    [Description("Product Id is required")]
    ProductIdRequired = 16
}
