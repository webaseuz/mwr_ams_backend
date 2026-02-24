using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Info.Contractors;

public class ContractorDtoProfile : Profile
{
    int lang = default;
    public ContractorDtoProfile()
    {
        //ContractorDto
        CreateMap<Contractor, ContractorDto>()
         .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
         .ForMember(src => src.Bank, conf => conf.MapFrom(ent => ent.Bank.FullName))
         .ForMember(src => src.RegionName, conf => conf.MapFrom(ent => ent.Region.FullName))
         .ForMember(src => src.CountryName, conf => conf.MapFrom(ent => ent.Country.FullName))
         .ForMember(src => src.DistrictName, conf => conf.MapFrom(ent => ent.District.FullName));
    }
}
