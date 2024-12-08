using System.ComponentModel;
using System.Reflection;

namespace MoviesApi.SharedKernel;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T value) where T : Enum
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());

        if (fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes &&
            attributes.Length != 0)
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}