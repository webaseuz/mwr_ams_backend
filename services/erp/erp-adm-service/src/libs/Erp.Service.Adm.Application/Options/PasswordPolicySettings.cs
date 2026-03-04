namespace Erp.Service.Adm.Application;

public static class PasswordPolicySettings
{
    public static int MinLength { get; } = 8;
    public static int MaxLength { get; } = 128;
    public static int MinStrengthScore { get; } = 6;
    public static bool CheckCommonPasswords { get; } = true;
    public static double MinEntropyThreshold { get; } = 3.0;
    public static List<string> CustomForbiddenWords { get; } = new()
    {
        "mad", "erp", "tashkent", "uzbekistan", "admin", "test", "demo"
    };
}
