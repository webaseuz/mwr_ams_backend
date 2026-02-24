using Bms.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace Bms.WEBASE.Controller;

public class WebaseController : ControllerBase
{
    protected ControllerConfig Config { get; }

    public WebaseController()
        : this(new ControllerConfig())
    {
    }

    public WebaseController(ControllerConfig config)
    {
        Config = config;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<SecurityInfoModel>), 200)]
    public virtual IActionResult GetSecurityInfo()
    {
        if (true || Config.EnableSecurityInfo)
        {
            List<SecurityInfoModel> value = ResolveSecurityInfos();
            return Ok(value);
        }

        return StatusCode(404);
    }

    private List<SecurityInfoModel> ResolveSecurityInfos()
    {
        var list = new List<SecurityInfoModel>();

        Type controllerType = GetType();

        string controllerName = controllerType.Name.Replace("Controller", "");

        var classAuthorizeAttributes = controllerType.GetCustomAttributes<AuthorizeAttribute>(inherit: true);

        var classPermissions = classAuthorizeAttributes
            .SelectMany(attr => (string[])attr.GetType().GetField("_permissions", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(attr) ?? Array.Empty<string>())
            .Distinct();

        bool classHasAuthorization = classAuthorizeAttributes.Any();

        foreach (MethodInfo method in controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public))
        {
            if (method.IsSpecialName || method.DeclaringType == typeof(ControllerBase) || method.DeclaringType == typeof(object))
                continue;

            var methodAuthorizeAttributes = method.GetCustomAttributes<AuthorizeAttribute>(inherit: true);
            var allowAnonymous = method.GetCustomAttributes<AllowAnonymousAttribute>(inherit: true).Any();

            var methodPermissions = methodAuthorizeAttributes
                .SelectMany(attr => (string[])attr.GetType().GetField("_permissions", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(attr) ?? Array.Empty<string>())
                .Distinct();

            bool methodHasAuthorization = methodAuthorizeAttributes.Any();

            var httpMethodAttribute = method.GetCustomAttribute<HttpMethodAttribute>();

            string httpMethod = httpMethodAttribute?.HttpMethods.FirstOrDefault() ?? "GET";

            string actionName = method.Name.EndsWith("Async") ? method.Name[..^5] : method.Name;

            var securityInfo = new SecurityInfoModel
            {
                Action = $"/{controllerName}/{actionName}",
                Method = httpMethod,
                UnauthorizedAccess = allowAnonymous || (!methodHasAuthorization && !classHasAuthorization),
                PermissionCodes = new HashSet<string>(classPermissions.Concat(methodPermissions))
            };

            if (!string.IsNullOrEmpty(httpMethodAttribute?.Template))
                securityInfo.Action += $"/{httpMethodAttribute.Template}";

            list.Add(securityInfo);
        }

        return list.OrderBy(x => x.Action).ToList();
    }

}
