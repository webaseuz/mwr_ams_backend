using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Nationalities;

public class CreateNationalityCommandProfile : Profile
{
    public CreateNationalityCommandProfile()
    {
        CreateMap<CreateNationalityCommand, Nationality>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
