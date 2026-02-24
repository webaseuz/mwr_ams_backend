namespace Bms.WEBASE.Security;

public interface ITokenProvider
{
    string Token { get; }
    string TokenHash { get; }
    void SetToken(string token);
}
