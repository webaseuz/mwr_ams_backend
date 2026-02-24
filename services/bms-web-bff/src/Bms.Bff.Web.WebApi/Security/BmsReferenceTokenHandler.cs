using System.Security.Claims;
using Bms.Common.Application.Security;

namespace Bms.Bff.Web.WebApi.Security;

/// <summary>
/// Wrapper for YOUR superior IAsyncReferenceTokenService - preserves database validation
/// </summary>
public class BmsReferenceTokenHandler : ITokenHandler
{
    private readonly IAsyncReferenceTokenService _referenceTokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public string ProviderName => "BMS-REFERENCE";

    public BmsReferenceTokenHandler(
        IAsyncReferenceTokenService referenceTokenService,
        IHttpContextAccessor httpContextAccessor)
    {
        _referenceTokenService = referenceTokenService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TokenValidationResult> ValidateTokenAsync(string token)
    {
        try
        {
            // Use YOUR superior async reference token validation with database check
            var validationResult = await _referenceTokenService.ValidateTokenAsync(token);
            
            if (validationResult != null && validationResult.IsValid)
            {
                return new TokenValidationResult
                {
                    IsValid = true,
                    Principal = validationResult.Principal,
                    AdditionalData = new Dictionary<string, object>
                    {
                        ["TokenType"] = "Reference",
                        ["Provider"] = ProviderName,
                        ["DatabaseValidated"] = true
                    }
                };
            }

            return new TokenValidationResult
            {
                IsValid = false,
                ErrorMessage = "Invalid reference token"
            };
        }
        catch (Exception ex)
        {
            return new TokenValidationResult
            {
                IsValid = false,
                ErrorMessage = $"Reference token validation error: {ex.Message}"
            };
        }
    }

    public async Task<string> GenerateTokenAsync(ClaimsPrincipal principal, Dictionary<string, object> additionalClaims = null)
    {
        // Use YOUR superior reference token generation with database storage
        var token = await _referenceTokenService.GenerateTokenAsync(principal);
        return token;
    }

    public string GetTokenFromRequest(HttpRequest request)
    {
        // Check Authorization header first
        var authHeader = request.Headers["Authorization"].FirstOrDefault();
        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            return authHeader.Substring("Bearer ".Length).Trim();
        }

        // Check custom header for reference tokens
        var referenceHeader = request.Headers["X-Reference-Token"].FirstOrDefault();
        if (!string.IsNullOrEmpty(referenceHeader))
        {
            return referenceHeader;
        }

        // Check query string (for special cases)
        if (request.Query.TryGetValue("ref_token", out var refToken))
        {
            return refToken;
        }

        return null;
    }
}