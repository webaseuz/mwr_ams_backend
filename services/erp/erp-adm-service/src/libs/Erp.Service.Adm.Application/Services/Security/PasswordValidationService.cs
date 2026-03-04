using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application;

public class PasswordValidationService : IPasswordValidationService
{

    private static readonly HashSet<string> CommonPasswords = new()
    {
        "123456", "password", "123456789", "12345678", "12345", "1234567",
        "qwerty", "abc123", "password123", "admin", "letmein", "welcome",
        "monkey", "1234567890", "dragon", "trustno1", "111111", "123123",
        "password1", "qwerty123", "welcome123", "admin123", "root", "toor",
        "pass", "test", "guest", "user", "demo", "temp"
    };

    private static readonly string[] KeyboardPatterns = {
        "qwerty", "asdf", "zxcv", "123456", "654321", "qwertyuiop",
        "asdfghjkl", "zxcvbnm", "йцукен", "фывапр", "ячсмить"
    };

    private static readonly string[] CommonWords = {
        "password", "admin", "user", "test", "demo", "guest", "root",
        "login", "account", "system", "access", "secure", "secret"
    };

    public bool IsCommonPassword(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;

        var lowerPassword = password.ToLower();
        return CommonPasswords.Contains(lowerPassword) ||
               PasswordPolicySettings.CustomForbiddenWords.Any(w => lowerPassword.Contains(w.ToLower()));
    }

    public bool ContainsUserInfo(string password, PersonCreateDto person)
    {
        if (string.IsNullOrEmpty(password) || person == null) return false;

        var lowerPassword = password.ToLower();
        var userInfo = new[]
        {
            person.FirstName?.ToLower(),
            person.LastName?.ToLower(),
            person.MiddleName?.ToLower(),
            person.Pinfl
        }.Where(info => !string.IsNullOrEmpty(info));

        return userInfo.Any(info => lowerPassword.Contains(info) || info.Contains(lowerPassword));
    }

    public double CalculateEntropy(string password)
    {
        if (string.IsNullOrEmpty(password)) return 0;

        var charsetSize = 0;
        if (password.Any(char.IsLower)) charsetSize += 26;
        if (password.Any(char.IsUpper)) charsetSize += 26;
        if (password.Any(char.IsDigit)) charsetSize += 10;
        if (password.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c))) charsetSize += 32;

        return password.Length * Math.Log2(charsetSize);
    }

    public int CalculateStrengthScore(string password, PersonCreateDto person = null)
    {
        if (string.IsNullOrEmpty(password)) return 0;

        int score = 0;

        // Length score (max 25 points)
        score += Math.Min(password.Length * 2, 25);

        // Character diversity (5 points each, max 20)
        if (password.Any(char.IsUpper)) score += 5;
        if (password.Any(char.IsLower)) score += 5;
        if (password.Any(char.IsDigit)) score += 5;
        if (password.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c))) score += 5;

        // Uniqueness bonus (max 10)
        if (password.Distinct().Count() == password.Length) score += 10;

        // Entropy bonus (max 20)
        var entropy = CalculateEntropy(password);
        score += Math.Min((int)(entropy / 2), 20);

        // Penalties
        if (ContainsUserInfo(password, person)) score -= 20;
        if (HasKeyboardPatterns(password)) score -= 15;
        if (HasSequentialChars(password)) score -= 10;
        if (HasRepeatingChars(password)) score -= 10;
        if (HasDictionaryWords(password)) score -= 15;

        return Math.Max(0, Math.Min(score, 100));
    }

    public bool HasKeyboardPatterns(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;
        var lowerPassword = password.ToLower();
        return KeyboardPatterns.Any(pattern => lowerPassword.Contains(pattern));
    }

    public bool HasSequentialChars(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 3) return false;

        for (int i = 0; i <= password.Length - 3; i++)
        {
            var char1 = password[i];
            var char2 = password[i + 1];
            var char3 = password[i + 2];

            if (char.IsDigit(char1) && char.IsDigit(char2) && char.IsDigit(char3))
            {
                var num1 = char1 - '0';
                var num2 = char2 - '0';
                var num3 = char3 - '0';

                if (num2 == num1 + 1 && num3 == num2 + 1) return true;
                if (num2 == num1 - 1 && num3 == num2 - 1) return true;
            }

            if (char.IsLetter(char1) && char.IsLetter(char2) && char.IsLetter(char3))
            {
                var lower1 = char.ToLower(char1);
                var lower2 = char.ToLower(char2);
                var lower3 = char.ToLower(char3);

                if (lower2 == lower1 + 1 && lower3 == lower2 + 1) return true;
                if (lower2 == lower1 - 1 && lower3 == lower2 - 1) return true;
            }
        }

        return false;
    }

    public bool HasRepeatingChars(string password, int maxRepeats = 3)
    {
        if (string.IsNullOrEmpty(password)) return false;

        for (int i = 0; i <= password.Length - maxRepeats; i++)
        {
            var currentChar = password[i];
            var repeatCount = 1;

            for (int j = i + 1; j < password.Length && password[j] == currentChar; j++)
            {
                repeatCount++;
                if (repeatCount >= maxRepeats) return true;
            }
        }

        return false;
    }

    public bool HasDictionaryWords(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;
        var lowerPassword = password.ToLower();
        return CommonWords.Any(word => lowerPassword.Contains(word));
    }

    public List<string> GetPasswordSuggestions(string password)
    {
        var suggestions = new List<string>();

        if (string.IsNullOrEmpty(password))
        {
            suggestions.Add("Parol kiritish majburiy");
            return suggestions;
        }

        if (password.Length < PasswordPolicySettings.MinLength)
            suggestions.Add($"Parol kamida {PasswordPolicySettings.MinLength} belgi bo'lishi kerak");

        if (password.Length > PasswordPolicySettings.MaxLength)
            suggestions.Add($"Parol {PasswordPolicySettings.MaxLength} belgidan oshmasligi kerak");

        if (!password.Any(char.IsUpper))
            suggestions.Add("Katta harflar qo'shing (A-Z)");

        if (!password.Any(char.IsLower))
            suggestions.Add("Kichik harflar qo'shing (a-z)");

        if (!password.Any(char.IsDigit))
            suggestions.Add("Raqamlar qo'shing (0-9)");

        if (!password.Any(c => "!@#$%^&*()_+-=[]{}|;:,.<>?".Contains(c)))
            suggestions.Add("Maxsus belgilar qo'shing (!@#$%^&*)");

        if (HasKeyboardPatterns(password))
            suggestions.Add("Klaviatura pattern'laridan foydalanmang (qwerty, 123456)");

        if (HasSequentialChars(password))
            suggestions.Add("Ketma-ket belgilardan qochining (abc, 123)");

        if (HasRepeatingChars(password))
            suggestions.Add("Takrorlanuvchi belgilarni kamaytiring");

        if (suggestions.Count == 0)
            suggestions.Add("Parol barcha talablarga javob beradi!");

        return suggestions;
    }
}
