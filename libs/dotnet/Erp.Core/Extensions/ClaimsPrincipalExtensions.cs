using System.Security.Claims;

namespace Erp.Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetKeycloakUsername(this ClaimsPrincipal user)
        {
            if (user == null || !user.Identity.IsAuthenticated)
                return string.Empty;

            // Keycloak claim priority
            return user.FindFirst("preferred_username")?.Value ??
                   user.FindFirst("username")?.Value ??
                   user.FindFirst(ClaimTypes.Name)?.Value ??
                   user.FindFirst("sub")?.Value ??
                   string.Empty;
        }
    }
}
