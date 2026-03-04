using WEBASE;

namespace Erp.Core.Models;

public static class StringUtility
{
    public static string GetShortFIO(string lastName, string firstName, string middleName)
    {
        static string GetInitial(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "";

            name = name.Trim().RemoveEnter().Replace(",", "").Replace(".", "").ToUpper();

            // O'zbekcha birinchi tovushlarni tekshirish
            if (name.StartsWith("CH")) return "Ch.";
            if (name.StartsWith("SH")) return "Sh.";
            if (name.StartsWith("G‘") || name.StartsWith("G'")) return "G‘.";
            if (name.StartsWith("O‘") || name.StartsWith("O'")) return "O‘.";

            return name.Substring(0, 1) + ".";
        }

        lastName = (lastName ?? "").RemoveEnter().Replace(",", "").Replace(".", "").Trim();

        string initials = GetInitial(firstName) + GetInitial(middleName);
        return $"{initials} {lastName}".Trim();
    }
}
