using Microsoft.AspNetCore.Mvc.Filters;

namespace Bms.Core.Presentation;

public class AllowAnonymousAttribute :
    Attribute,
    IFilterMetadata
{
}
