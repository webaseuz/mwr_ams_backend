using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class SpareMovementBriefDtoProfile 
	: Profile
{
    public SpareMovementBriefDtoProfile()
    {
        int lang = default;

        CreateMap<SpareMovement, SpareMovementBriefDto>()
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
            .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
            .ForMember(src => src.MovementTypeName, conf => conf.MapFrom(ent => ent.MovementType.Translates.AsQueryable()
            .FirstOrDefault(MovementTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.MovementType.FullName))
            .ForMember(src => src.ToUserName, conf => conf.MapFrom(ent => ent.ToUser.UserName))
            .ForMember(src => src.FromUserName, conf => conf.MapFrom(ent => ent.FromUser.UserName))
            .ForMember(src => src.ToBranchName, conf => conf.MapFrom(ent => ent.ToBranch.FullName))
            .ForMember(src => src.FromBranchName, conf => conf.MapFrom(ent => ent.FromBranch.FullName))
            ;
    }
}
