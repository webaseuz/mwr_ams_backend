using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using WEBASE;

namespace Erp.Core;

public static class StringExtensions
{
    //thanks to https://stackoverflow.com/questions/3565015/bestpractice-transform-first-character-of-a-string-into-lower-case
    public static string ToLowerFirstChar(this string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input));
        return input.First().ToString().ToLower() + input.Substring(1);
    }

    public static string SafeSubstring(this string input, int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), "Substring length cannot be less than 0");

        if (string.IsNullOrEmpty(input) || input.Length <= length)
            return input;

        return input.Substring(0, length);
    }

    public static string NormalizeOracleError(this string errorMessage)
    {
        errorMessage = errorMessage.Replace("\n", "");

        string pattern = @"ORA-\d+: (.*?)\b(?=ORA-\d+:|$)";

        // Отображаем только текст ошибки RAISE_APPLICATION_ERROR
        MatchCollection matches = Regex.Matches(errorMessage, pattern);

        // Отображаем полный текст ошибки Oracle
        return matches[0].Groups[1].Value;
    }

    public static DateTime? GetBirthDateByPinfl(this string input)
    {
        DateTime? birthDate = null;

        if (!string.IsNullOrWhiteSpace(input) && input.Length == 14)
        {
            string century = input[0] switch
            {
                '1' => "18",
                '2' => "18",
                '3' => "19",
                '4' => "19",
                '5' => "20",
                '6' => "20",  // 1994
                _ => "19",
            };

            var year = int.Parse($"{century}{input.Substring(5, 2)}");
            var month = int.Parse(input.Substring(3, 2));
            var day = int.Parse(input.Substring(1, 2));
            try
            {
                birthDate = new(year, month > 0 ? month : 1, day > 0 ? day : 1);
            }
            catch { }
        }

        return birthDate;
    }

    public static DateTime? ParseExactNullable(this string input, string format)
    {
        DateTime? birthDate = null;

        if (!string.IsNullOrWhiteSpace(input))
        {
            DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        }

        return birthDate;
    }

    public static (string Letters, string Numbers) DocumentToSeriaNumber(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return (null, null);

        var letters = new StringBuilder();
        var numbers = new StringBuilder();

        if (string.IsNullOrEmpty(input))
            return (letters.ToString(), numbers.ToString());

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                numbers.Append(c);
            }
            else
            {
                letters.Append(c); //Metirka uchun SU-I2449321
            }
        }

        return (letters.ToString(), numbers.ToString());
    }

    public static int FromFractionToPercentage(this string fraction)
    {
        string[] parts = fraction.Split('/');

        if (parts.Length != 2)
        {
            throw new ArgumentException("Invalid fraction format");
        }

        if (!int.TryParse(parts[0], out int numerator) || !int.TryParse(parts[1], out int denominator))
        {
            throw new ArgumentException("Invalid fraction format");
        }

        double percentage = (double)numerator / denominator * 100;

        return (int)percentage;
    }

    public static bool IsValidPinfl(this string pinfl)
    {
        return !string.IsNullOrWhiteSpace(pinfl)
               && pinfl.Length == 14
               && pinfl.All(char.IsDigit);
    }

    public static string ToUzbekWeekName(this int weekNumber)
    {
        string[] UzWeekDays =
                 {
                        "Dushanba",   // 1
                        "Seshanba",   // 2
                        "Chorshanba", // 3
                        "Payshanba",  // 4
                        "Juma",       // 5
                        "Shanba",     // 6
                        "Yakshanba"   // 7
                    };
        if (weekNumber < 1 || weekNumber > 7)
            throw new ArgumentOutOfRangeException(nameof(weekNumber), "Week number must be between 1 and 7.");

        return UzWeekDays[weekNumber - 1];
    }
}
