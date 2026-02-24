using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilModels;

public class UpdateOilModelCommandProfile :
    Profile
{
    public UpdateOilModelCommandProfile()
    {
        CreateMap<UpdateOilModelCommand, OilModel>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
