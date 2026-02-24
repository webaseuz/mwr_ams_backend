namespace Bms.Core.Application;
public static class PhoneNumberExtensions
{
    public static string NormalizePhoneNumber(this string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return phoneNumber;

        phoneNumber = phoneNumber.Replace("+", "")
                                 .Replace("-", "")
                                 .Replace("(", "")
                                 .Replace(")", "")
                                 .Replace(" ", "");

        if (phoneNumber.Length == 9)
            phoneNumber = "998" + phoneNumber;

        return phoneNumber;
    }

    public static bool IsValidPhoneNumberFormat(this string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return false;
        string normalizedNumber = phoneNumber.NormalizePhoneNumber();

        // 13 length
        if (normalizedNumber.Length != 12)
        {
            if (normalizedNumber.Length == 4)
            {

            }
            else return false;
        }

        // +998
        if (phoneNumber.StartsWith("+998") == false)
        {
            if (phoneNumber.Length == 4)
            {

            }
            else return false;
        }

        foreach (var item in normalizedNumber)
            if (char.IsDigit(item) == false)
                return false;

        return true;
    }
}