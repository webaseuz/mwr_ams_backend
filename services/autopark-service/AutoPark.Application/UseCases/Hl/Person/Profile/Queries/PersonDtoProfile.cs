using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Persons;

public class PersonDtoProfile : Profile
{
    public PersonDtoProfile()
    {
        int lang = default;
        //PersonDto
        CreateMap<Person, PersonDto>()
            .ForMember(src => src.BirthRegionName, conf => conf.MapFrom(x => x.BirthRegion.Translates.AsQueryable()
            .FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.BirthDistrictName, conf => conf.MapFrom(x => x.BirthDistrict.Translates.AsQueryable()
            .FirstOrDefault(DistrictTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.BirthCountryName, conf => conf.MapFrom(x => x.BirthCountry.Translates.AsQueryable()
            .FirstOrDefault(CountryTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.CitizenshipName, conf => conf.MapFrom(x => x.Citizenship.Translates.AsQueryable()
            .FirstOrDefault(CitizenshipTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.DocumentTypeName, conf => conf.MapFrom(x => x.DocumentType.Translates.AsQueryable()
            .FirstOrDefault(DocumentTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.GenderName, conf => conf.MapFrom(x => x.Gender.Translates.AsQueryable()
            .FirstOrDefault(GenderTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.LivingRegionName, conf => conf.MapFrom(x => x.LivingRegion.Translates.AsQueryable()
            .FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.LivingDistrictName, conf => conf.MapFrom(x => x.LivingDistrict.Translates.AsQueryable()
            .FirstOrDefault(DistrictTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? x.FullName))
            .ForMember(src => src.BranchName, conf => conf.MapFrom(x => x.Branch.FullName))
            ;
    }
}
