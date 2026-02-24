using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Citizenships;

public class UpdateCitizenshipCommandProfile : Profile
{
    public UpdateCitizenshipCommandProfile()
    {
        CreateMap<UpdateCitizenshipCommand, Citizenship>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
