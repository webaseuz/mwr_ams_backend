namespace Bms.WEBASE.Extensions;

public static class StringExtensions
{
    public static bool NullOrWhiteSpace(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static bool NullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    public static TEnum AsEnum<TEnum>(this string value)
        where TEnum : struct
    {
        if (Enum.TryParse(value, out TEnum result))
            return result;

        return default;
    }

    public static object AsEnum(this string value, Type enumType)
    {
        if (Enum.TryParse(enumType, value, out object result))
            return result;

        return default;
    }

    private static readonly string[] DoubleChars = new string[14]
    {
        "sh", "ch", "ya", "yo", "yu", "o'", "o`", "o‘", "o’", "g'",
        "g’", "g`", "g‘", "g’"
    };

    public static bool IsNullOrEmptyObject(this object value)
    {
        if (value == null)
        {
            return true;
        }

        return string.IsNullOrWhiteSpace(value.ToString());
    }

    public static string LeadingZero(this string input, int ZeroCount)
    {
        if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
        {
            return input;
        }

        if (ZeroCount < 1)
        {
            return input;
        }

        if (input.Length < ZeroCount)
        {
            return input.PadLeft(ZeroCount, '0');
        }

        return input;
    }

    public static string RemoveEnter(this string input)
    {
        if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
        {
            return input;
        }

        return input.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ")
            .Replace("  ", " ");
    }

    public static string CapitalizeFirstChar(this string input, bool Sanitize = true)
    {
        if (string.IsNullOrEmpty(input) || input.Trim().Length == 0)
        {
            return input;
        }

        input = input.Trim();
        if (Sanitize)
        {
            input = input.RemoveEnter();
            List<string> list = new List<string>();
            list.Add(",");
            list.Add(".");
            list.Add("#");
            list.Add("+");
            list.Add("/");
            list.Add("*");
            list.Add("!");
            list.Add("@");
            list.Add("$");
            list.Add("%");
            list.Add("^");
            list.Add("&");
            list.ForEach(delegate (string removechar)
            {
                input = input.Replace(removechar, "");
            });
        }

        return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
    }

    public static string GetFullFIO(string input1, string input2, string input3)
    {
        if (string.IsNullOrEmpty(input1))
        {
            input1 = "";
        }

        if (string.IsNullOrEmpty(input2))
        {
            input2 = "";
        }

        if (string.IsNullOrEmpty(input3))
        {
            input3 = "";
        }

        input1 = input1.RemoveEnter().Replace(",", "").Replace(".", "");
        input2 = input2.RemoveEnter().Replace(",", "").Replace(".", "");
        input3 = input3.RemoveEnter().Replace(",", "").Replace(".", "");
        return input1 + " " + input2 + ((input3.Length > 0) ? (" " + input3) : "");
    }

    public static string GetFIO(this string input)
    {
        if (input == "" || input == null)
        {
            return "";
        }

        string text = "";
        try
        {
            input = input.Trim();
            string[] fio = input.Split(new string[1] { " " }, StringSplitOptions.None);
            if (fio.Length >= 3)
            {
                string value = fio[1].Substring(0, (!DoubleChars.Any((string a) => fio[1].ToLower().StartsWith(a))) ? 1 : 2);
                string value2 = fio[2].Substring(0, (!DoubleChars.Any((string a) => fio[1].ToLower().StartsWith(a))) ? 1 : 2);
                text = $"{value}.{value2}.{fio[0]}";
            }
            else
            {
                text = fio[1].Substring(0, (!DoubleChars.Any((string a) => fio[1].ToLower().StartsWith(a))) ? 1 : 2) + "." + fio[0];
            }
        }
        catch
        {
        }

        if (text == "")
        {
            return input;
        }

        return text;
    }

    public static string RemoveUzbekChars(string input)
    {
        if (input == null)
        {
            return "";
        }

        input = input.Trim();
        string[] array = new string[11]
        {
            "Қ", "қ", "Ғ", "ғ", "Ҳ", "ҳ", "Ў", "ў", "\r", "\t",
            "\n"
        };
        string[] array2 = new string[11]
        {
            "К", "к", "Г", "г", "Х", "х", "У", "у", "", "",
            ""
        };
        for (int i = 0; i < array.Count(); i++)
        {
            input = input.Replace(array[i], array2[i]);
        }

        return input;
    }

    public static string SumToTreasury(decimal Value)
    {
        return (Value * 100m).ToString().Replace(",00", "").Replace(".00", "");
    }

    public static string SumToTreasury2(decimal Value)
    {
        return Value.ToString().Replace(",", "").Replace(".", "");
    }

}
