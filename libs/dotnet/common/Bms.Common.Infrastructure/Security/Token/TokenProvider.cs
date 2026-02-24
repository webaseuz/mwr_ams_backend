using Bms.WEBASE.Helpers;

namespace Bms.WEBASE.Security;

public class TokenProvider :
    ITokenProvider
{
    public string Token { get; private set; }
    public string TokenHash => HashHelper.ComputeSimpleHash(Token);

    public void SetToken(string token)
        => Token = token;

}