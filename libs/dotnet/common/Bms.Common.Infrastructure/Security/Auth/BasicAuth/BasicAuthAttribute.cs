using Microsoft.AspNetCore.Mvc;

namespace Bms.WEBASE.Security;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class BasicAuthAttribute : TypeFilterAttribute
{
    public BasicAuthAttribute(string realm = "My Realm")
        : base(typeof(BasicAuthFilter))
    {
        base.Arguments = new object[1] { realm };
    }
}
