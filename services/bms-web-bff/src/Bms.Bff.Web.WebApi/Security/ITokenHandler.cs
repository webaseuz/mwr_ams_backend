using System.Security.Claims;

namespace Bms.Bff.Web.WebApi.Security;

/// <summary>
/// Flexible token handler interface that wraps your existing superior token services
/// </summary>
public interface ITokenHandler
{
    Task<TokenValidationResult> ValidateTokenAsync(string token);
    Task<string> GenerateTokenAsync(ClaimsPrincipal principal, Dictionary<string, object> additionalClaims = null);
    string GetTokenFromRequest(HttpRequest request);
    string ProviderName { get; }
}

public class TokenValidationResult
{
    public bool IsValid { get; set; }
    public ClaimsPrincipal Principal { get; set; }
    public string ErrorMessage { get; set; }
    public Dictionary<string, object> AdditionalData { get; set; } = new();
}