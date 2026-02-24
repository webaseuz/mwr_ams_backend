using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;
using Bms.WEBASE.DependencyInjection;

namespace AutoPark.Application.UseCases.Accounts;

public class TokenUserInfoDtoProfile : Profile
{
    public TokenUserInfoDtoProfile()
    {
        CreateMap<User, UserInfoDto>()
            .ForMember(src => src.IsAdmin, exp => exp.MapFrom(ent => ent.UserRoles.Any(ur => ur.Role.IsAdmin)))
            .ForMember(src => src.Pinfl, exp => exp.MapFrom(ent => ent.Person.Pinfl))
            .ForMember(src => src.Inn, exp => exp.MapFrom(ent => ent.Person.Inn))
            .ForMember(src => src.Permissions, exp => exp.MapFrom(ent => ent.UserRoles
                .Where(ur => ur.StateId == StateIdConst.ACTIVE)
                .SelectMany(b => b.Role.RolePermissions.Select(rm => rm.Permission.Code))))
            .ForMember(src => src.LanguageCode, exp => exp.MapFrom(ent => ent.Language.ShortName))
            .ForMember(src => src.BranchName, exp => exp.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.DepartmentName, exp => exp.MapFrom(ent => ent.Department.Translates.AsQueryable().FirstOrDefault(DepartmentTranslate.GetExpr(TranslateColumn.short_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.Department.ShortName))
            .ForMember(src => src.PositionName, exp => exp.MapFrom(ent => ent.Position.Translates.AsQueryable().FirstOrDefault(PositionTranslate.GetExpr(TranslateColumn.short_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.Position.ShortName));
    }
}
