using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Nationalities;

public class UpdateNationalityCommandProfile : Profile
{
    public UpdateNationalityCommandProfile()
    {
        CreateMap<UpdateNationalityCommand, Nationality>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}