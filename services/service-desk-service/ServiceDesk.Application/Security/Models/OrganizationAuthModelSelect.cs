using ServiceDesk.Domain;

namespace ServiceDesk.Application.Security;

public static class OrganizationAuthModelSelect
{
    public static IQueryable<OrganizationAuthModel> MapToOrganizationModel(this IQueryable<Organization> Organizations)
    {
        return Organizations.Select(a => new OrganizationAuthModel 
        {
            Id = a.Id,
            Inn = a.Inn,
            ShortName = a.ShortName,            
            FullName = a.FullName,
            RegionId = a.RegionId
        });
    }
}
