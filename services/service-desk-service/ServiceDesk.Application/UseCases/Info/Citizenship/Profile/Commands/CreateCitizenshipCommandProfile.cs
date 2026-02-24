using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CreateCitizenshipCommandProfile : Profile
{
    public CreateCitizenshipCommandProfile()
    {
        CreateMap<CreateCitizenshipCommand, Citizenship>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}