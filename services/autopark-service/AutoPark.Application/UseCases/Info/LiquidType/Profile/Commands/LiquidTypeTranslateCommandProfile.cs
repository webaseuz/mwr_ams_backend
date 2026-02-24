using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

class LiquidTypeTranslateCommandProfile : Profile
{
    public LiquidTypeTranslateCommandProfile()
    {
        CreateMap<LiquidTypeTranslateCommand, LiquidTypeTranslate>();
    }
}
