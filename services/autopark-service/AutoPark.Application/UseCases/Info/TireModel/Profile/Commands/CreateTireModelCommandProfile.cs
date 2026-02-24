using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TireModels;

public class CreateTireModelCommandProfile :
    Profile
{
    public CreateTireModelCommandProfile()
    {
        CreateMap<CreateTireModelCommand, TireModel>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
