using System.Reflection;

namespace Erp.Core;

public class AppIdConst
{
    public const int ADM = 1;
    public const int HRM = 2;
    public const int ORG = 3;
    public const int STD = 4;
    public const int MY = 5;
    public const int COM = 6;
    public const int FIN = 7;
    public const int DASH = 8;
    public const int LMS = 9;
    public const int APP = 10;
    public const int REPR = 11;
    public const int LINK = 12;
    public const int ITG = 13;
    public const int LOGGER = 14;
    public const int CERT = 15;

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

public class CustomJobTypeIdConst
{
    public const int SYNC_USER_WITH_EMPLOYEE = 1;  
    public const int UPDATE_PERSON_DATA = 2;
}
