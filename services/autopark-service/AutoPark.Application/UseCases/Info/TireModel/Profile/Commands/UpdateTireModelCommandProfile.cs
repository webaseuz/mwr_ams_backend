using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TireModels;

public class UpdateTireModelCommandProfile :
    Profile
{
    public UpdateTireModelCommandProfile()
    {
        CreateMap<UpdateTireModelCommand, TireModel>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
