using Erp.Core.Service.Domain;

namespace Erp.Service.Adm.Job.Application;
public static class OrganizationAuthModelSelect
{
    public static OrganizationAuthModel MapToAuthModel(this Organization organization)
    {
        if (organization == null)
            return null;

        int languageId = 3;

        return new OrganizationAuthModel
        {
            Id = organization.Id,
            ShortName = organization.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.short_name, languageId: languageId))?.TranslateText ?? organization.ShortName,
            FullName = organization.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name, languageId: languageId))?.TranslateText ?? organization.FullName,
            Inn = organization.Inn,
            RegionId = organization.RegionId,
            DistrictId = organization.DistrictId,
            //OrganizationalStructureId = organization.OrganizationalStructureId
        };
    }
}
