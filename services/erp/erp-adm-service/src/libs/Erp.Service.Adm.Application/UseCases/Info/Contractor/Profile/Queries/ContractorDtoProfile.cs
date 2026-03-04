using Erp.Core.Service.Application;
using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class ContractorDtoProfile : CultureProfile
{
    public ContractorDtoProfile()
    {
        var cultureId = 1;
        //ContractorDto
        CreateMap<Contractor, ContractorDto>()
         .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.State.FullName))
         .ForMember(src => src.Bank, conf => conf.MapFrom(ent => ent.Bank.FullName))
         .ForMember(src => src.RegionName, conf => conf.MapFrom(ent => ent.Region.FullName))
         .ForMember(src => src.CountryName, conf => conf.MapFrom(ent => ent.Country.FullName))
         .ForMember(src => src.DistrictName, conf => conf.MapFrom(ent => ent.District.FullName));
    }
}
