using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class BatteryTypeTranslateCommandProfile : Profile
{
    public BatteryTypeTranslateCommandProfile()
    {
        CreateMap<BatteryTypeTranslateCommand, BatteryTypeTranslate>();
    }
}
