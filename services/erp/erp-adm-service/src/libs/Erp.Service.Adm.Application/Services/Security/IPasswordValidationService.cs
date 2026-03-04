using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application;

public interface IPasswordValidationService
{
    bool IsCommonPassword(string password);
    bool ContainsUserInfo(string password, PersonCreateDto person);
    double CalculateEntropy(string password);
    int CalculateStrengthScore(string password, PersonCreateDto person = null);
    bool HasKeyboardPatterns(string password);
    bool HasSequentialChars(string password);
    bool HasRepeatingChars(string password, int maxRepeats = 3);
    bool HasDictionaryWords(string password);
    List<string> GetPasswordSuggestions(string password);
}
