namespace AutoPark.Application.HelperService;

public class PinflHelper : IPinflHelper
{
    int[] SPECIALNUMBERS = new int[] { 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 3, 1, 7, 0 };
    public bool IsValid(string pinfl)
    {
        var dayOfMonths = new Dictionary<int, int>
        {
            { 1, 31 },
            { 2, 28 },
            { 3, 31 },
            { 4, 30 },
            { 5, 31 },
            { 6, 30 },
            { 7, 31 },
            { 8, 31 },
            { 9, 30 },
            { 10, 31 },
            { 11, 30 },
            { 12, 31 }
        };

        if (pinfl.Length != 14 || pinfl.Any(a => !char.IsDigit(a)))
            return false;

        var centuryCode = int.Parse(pinfl.Substring(0, 1));

        if (centuryCode < 1 || centuryCode > 6)
            return false;

        var month = int.Parse(pinfl.Substring(3, 2));

        if (month < 1 || month > 12)
            return false;

        var yearCode = int.Parse(pinfl.Substring(5, 2));
        var year = 1800 + 100 * ((centuryCode - 1) / 2) + yearCode;

        if (year > DateTime.Now.Year)
            return false;

        if (IsCabissian(year))
            dayOfMonths[2]++;

        var day = int.Parse(pinfl.Substring(1, 2));

        if (day < 1 || day > dayOfMonths[month])
            return false;

        if (pinfl.Substring(7, 3).Equals("000"))
            return false;

        if (pinfl.Substring(10, 3).Equals("000"))
            return false;

        var controlNumber = pinfl.Select((c, i) => (c - '0') * SPECIALNUMBERS[i]).Sum() % 10;

        if (int.Parse(pinfl.Substring(13, 1)) != controlNumber)
            return false;

        return true;
    }

    private bool IsCabissian(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }
}
