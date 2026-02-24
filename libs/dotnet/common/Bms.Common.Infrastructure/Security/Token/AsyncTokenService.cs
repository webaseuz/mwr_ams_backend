using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.Security;

public abstract class AsyncTokenService :
    IAsyncTokenService
{
    public abstract Task<TokenResult> GenerateTokenAsync(string userIdentity);

    public abstract Task<TokenResult> GenerateTokenAsync(string userIdentity,
                                                         TimeSpan expireInterval);

    public abstract Task<bool> ValidateTokenAsync(string token);
}
