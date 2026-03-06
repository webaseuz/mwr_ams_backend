using System.Reflection;

namespace Erp.Core;

public class AppIdConst
{
    public const int ADM      = 1;
    public const int FIN      = 2;
    public const int AUTOPARK = 3;
    public const int INV      = 4;
    public const int QR       = 5;

    public static string GetStringById(int appId)
    {
        var fields = typeof(AppIdConst)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

        foreach (var field in fields)
        {
            if (field.FieldType == typeof(int) &&
                (int)field.GetValue(null)! == appId)
            {
                return field.Name;
            }
        }

        throw new KeyNotFoundException();
    }

    public static int GetIdByString(string appCode)
    {
        var field = typeof(AppIdConst)
            .GetField(appCode, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);

        if (field != null && field.FieldType == typeof(int))
        {
            return (int)field.GetValue(null)!;
        }

        throw new KeyNotFoundException();
    }
}
