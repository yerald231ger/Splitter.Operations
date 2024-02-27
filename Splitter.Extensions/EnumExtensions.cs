using System.ComponentModel;

namespace Splitter.Extensions;

public static class EnumExtensions
{

    public static string GetDescription(this Enum code)
    {
        var fieldInfo = code.GetType().GetField(code.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : code.ToString();
    }
}

