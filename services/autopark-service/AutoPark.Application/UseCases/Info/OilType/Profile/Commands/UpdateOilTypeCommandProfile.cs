using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilTypes;

public class UpdateOilTypeCommandProfile :
    Profile
{
    public UpdateOilTypeCommandProfile()
    {
        CreateMap<UpdateOilTypeCommand, OilType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
