using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class CreateLiquidTypeCommandProfile : Profile
{
    public CreateLiquidTypeCommandProfile()
    {
        CreateMap<CreateLiquidTypeCommand, LiquidType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
