using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Persons;

public class PersonDtoProfile : Profile
{
    public PersonDtoProfile()
    {
        //PersonDto
        CreateMap<Person, PersonDto>()
            .ForMember(src => src.BirthRegionName, conf => conf.MapFrom(x => x.BirthRegion.FullName))
            .ForMember(src => src.BirthDistrictName, conf => conf.MapFrom(x => x.BirthDistrict.FullName))
            .ForMember(src => src.BirthCountryName, conf => conf.MapFrom(x => x.BirthCountry.FullName))
            .ForMember(src => src.CitizenshipName, conf => conf.MapFrom(x => x.Citizenship.FullName))
            .ForMember(src => src.LivingRegionName, conf => conf.MapFrom(x => x.LivingRegion.FullName))
            .ForMember(src => src.LivingDistrictName, conf => conf.MapFrom(x => x.LivingDistrict.FullName));
    }
}
