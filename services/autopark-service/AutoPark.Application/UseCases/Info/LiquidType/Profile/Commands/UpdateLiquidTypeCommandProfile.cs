using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class UpdateLiquidTypeCommandProfile : Profile
{
    public UpdateLiquidTypeCommandProfile()
    {

        CreateMap<UpdateLiquidTypeCommand, LiquidType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
