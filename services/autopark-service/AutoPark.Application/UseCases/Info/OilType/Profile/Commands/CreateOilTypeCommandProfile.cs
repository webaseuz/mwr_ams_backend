using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilTypes;

public class CreateOilTypeCommandProfile :
    Profile
{
    public CreateOilTypeCommandProfile()
    {
        CreateMap<CreateOilTypeCommand, OilType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
