using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilModels;

public class CreateOilModelCommandProfile :
    Profile
{
    public CreateOilModelCommandProfile()
    {
        CreateMap<CreateOilModelCommand, OilModel>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
