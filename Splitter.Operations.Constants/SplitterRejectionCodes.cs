using System.ComponentModel;
using Splitter.Operations.Constants;

namespace Splitter.Operations.Constants;

public enum SptRejectCodes
{
    [Description("Invalid Commensality Name. Must not be empty")]
    InvalidCommensalityName = 1,

    [Description("Commensality Not Found. Check the Commensality Id and try again")]
    CommensalityNotFound = 2,

    [Description("Invalid Product Name. Must not be empty")]
    InvalidProductName = 3,

    [Description("Order Not Found. Check the Order Id and try again")]
    OrderNotFound = 4,

    [Description("Order Already Paid")]
    OrderAlreadyPaid = 5,

    [Description("Insufficient Funds")]
    InsufficientFunds = 6,

    [Description("Invalid Tip value. Must be greater than 0.00 and less than 100.00")]
    InvalidTip = 7,

    [Description("Repository Error")]
    RepositoryError = 8,

    [Description("From date cannot be greater than To date")]
    InvalidSearchRange = 9,

    [Description("Resource not found")]
    NotFound = 10,

    [Description("Invalid Resource Identifier")]
    InvalidResourceIdentifier = 11,

    [Description("Order without products")]
    OrderWithoutProducts = 12
}

public static class SptRejectCodesExtensions
{
    public static string GetDescription(this SptRejectCodes code)
    {
        SptRejectCodes.InvalidTip.ToString();
        var fieldInfo = code.GetType().GetField(code.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : code.ToString();
    }
}