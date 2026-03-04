using Microsoft.AspNetCore.Mvc;
using Erp.Core;
using WEBASE.AspNet;

namespace Erp.Service.Adm.Job.WebApi;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorizeAttribute : TypeFilterAttribute
{
    public AuthorizeAttribute()
        : base(typeof(WbAuthorizeFilter))
    {
        Arguments = new[] {
            new string[] { }
        };
    }

    public AuthorizeAttribute(params AdmPermissionCode[] permissionCodes)
        : base(typeof(WbAuthorizeFilter))
    {
        Arguments = new[] { permissionCodes.Select(c => c.ToString()).ToArray() };
    }
}
