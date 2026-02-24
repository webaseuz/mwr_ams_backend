using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Nationalities;

public class UpdateNationalityCommandProfile : Profile
{
    public UpdateNationalityCommandProfile()
    {
        CreateMap<UpdateNationalityCommand, Nationality>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}