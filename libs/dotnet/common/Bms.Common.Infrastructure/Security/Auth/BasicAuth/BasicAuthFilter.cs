using Bms.WEBASE.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Text;

namespace Bms.WEBASE.Security;

public class BasicAuthFilter :
    IAuthorizationFilter,
    IFilterMetadata
{
    private readonly string _realm;

    public BasicAuthFilter(string realm)
    {
        _realm = realm;

        if (string.IsNullOrWhiteSpace(_realm))
            throw new ArgumentNullException("realm", "Please provide a non-empty realm value.");
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            string text = context.HttpContext.Request.Headers["Authorization"];

            if (text != null)
            {
                AuthenticationHeaderValue authenticationHeaderValue = AuthenticationHeaderValue.Parse(text);

                if (authenticationHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    string[] array = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter ?? string.Empty)).Split(':', 2);

                    if (array.Length == 2 && IsAuthorized(context, array[0], array[1]))
                        return;
                }
            }

            ReturnUnauthorizedResult(context);
        }
        catch (FormatException)
        {
            ReturnUnauthorizedResult(context);
        }
    }

    public bool IsAuthorized(AuthorizationFilterContext context, string username, string password)
    {
        BasicAuthRealmConfig basicAuthRealmConfig = context.HttpContext.RequestServices.GetRequiredService<BasicAuthConfig>().Realms.Single((BasicAuthRealmConfig a) => a.Realm == _realm);

        string userip = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

        if (userip != "127.0.0.1" && context.HttpContext.Request.Headers.ContainsKey("X -Forwarded-For"))
            userip = context.HttpContext.Request.Headers["X-Forwarded-For"];

        if (context.HttpContext.Request.Headers.ContainsKey("User-Agent"))
            _ = (string)context.HttpContext.Request.Headers["User-Agent"];

        if (basicAuthRealmConfig.IpList.Length != 0)
        {
            if (!basicAuthRealmConfig.IpList.Any((string a) => a == userip))
                return false;

            if (basicAuthRealmConfig.Login.NullOrEmpty() && basicAuthRealmConfig.Password.NullOrEmpty())
                return true;
        }

        if (!basicAuthRealmConfig.Login.NullOrEmpty() && !basicAuthRealmConfig.Password.NullOrEmpty() && basicAuthRealmConfig.Login.ToLower() == username.ToLower() && basicAuthRealmConfig.Password == password)
            return true;

        return false;
    }

    private void ReturnUnauthorizedResult(AuthorizationFilterContext context)
    {
        context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"" + _realm + "\"";
        context.Result = new UnauthorizedResult();
    }
}
