using Microsoft.AspNetCore.Mvc;
using Erp.Core;

namespace Erp.Adm.Bff.Web.WebApi;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorizeAttribute : TypeFilterAttribute
{
    public AuthorizeAttribute()
        : base(typeof(AuthorizeFilter))
    {
        //Arguments = new[] { 
        //    new string[] { } 
        //};
    }

    //public AuthorizeAttribute(params AdmPermissionCode[] permissionCodes)
    //    : base(typeof(AuthorizeFilter))
    //{
    //    Arguments = new[] { permissionCodes.Select(c => c.ToString()).ToArray() };
    //}
}
