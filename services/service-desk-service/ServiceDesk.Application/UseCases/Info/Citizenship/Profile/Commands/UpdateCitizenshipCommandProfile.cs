using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class UpdateCitizenshipCommandProfile : Profile
{
    public UpdateCitizenshipCommandProfile()
    {
        CreateMap<UpdateCitizenshipCommand, Citizenship>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
