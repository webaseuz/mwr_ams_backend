namespace Erp.Service.Adm.Application;

public interface ITokenService
{
    Task<TokenResult> GenerateTokenAsync(string userIdentity);
    Task<TokenResult> GenerateRefreshTokenAsync();
}
