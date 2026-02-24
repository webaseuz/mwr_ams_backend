using Microsoft.AspNetCore.Mvc.Filters;

namespace Bms.Common.Infrastructure;

public class AllowAnonymousAttribute :
    Attribute,
    IFilterMetadata
{
}
