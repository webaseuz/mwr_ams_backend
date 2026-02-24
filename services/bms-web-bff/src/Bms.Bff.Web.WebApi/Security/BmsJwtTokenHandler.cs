using System.Security.Claims;
using Bms.Common.Application.Security;
using Bms.Common.Infrastructure.Security.Token;

namespace Bms.Bff.Web.WebApi.Security;

/// <summary>
/// Wrapper for YOUR superior IJwtTokenService - preserves all existing functionality
/// </summary>
public class BmsJwtTokenHandler : ITokenHandler
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public string ProviderName => "BMS-JWT";

    public BmsJwtTokenHandler(
        IJwtTokenService jwtTokenService,
        IHttpContextAccessor httpContextAccessor)
    {
        _jwtTokenService = jwtTokenService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TokenValidationResult> ValidateTokenAsync(string token)
    {
        try
        {
            // Use YOUR superior JWT validation
            var validationResult = _jwtTokenService.ValidateToken(token);
            
            if (validationResult != null && validationResult.IsValid)
            {
                return new TokenValidationResult
                {
                    IsValid = true,
                    Principal = validationResult.Principal,
                    AdditionalData = new Dictionary<string, object>
                    {
                        ["TokenType"] = "JWT",
                        ["Provider"] = ProviderName
                    }
                };
            }

            return new TokenValidationResult
            {
                IsValid = false,
                ErrorMessage = "Invalid JWT token"
            };
        }
        catch (Exception ex)
        {
            return new TokenValidationResult
            {
                IsValid = false,
                ErrorMessage = $"Token validation error: {ex.Message}"
            };
        }
    }

    public async Task<string> GenerateTokenAsync(ClaimsPrincipal principal, Dictionary<string, object> additionalClaims = null)
    {
        // Use YOUR superior JWT generation
        var token = _jwtTokenService.GenerateToken(principal);
        return await Task.FromResult(token);
    }

    public string GetTokenFromRequest(HttpRequest request)
    {
        // Check Authorization header first
        var authHeader = request.Headers["Authorization"].FirstOrDefault();
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            return authHeader.Substring("Bearer ".Length).Trim();
        }

        // Check custom header (if your system uses it)
        var customHeader = request.Headers["X-Auth-Token"].FirstOrDefault();
        if (!string.IsNullOrEmpty(customHeader))
        {
            return customHeader;
        }

        // Check query string (for SignalR or special cases)
        if (request.Query.TryGetValue("access_token", out var accessToken))
        {
            return accessToken;
        }

        return null;
    }
}