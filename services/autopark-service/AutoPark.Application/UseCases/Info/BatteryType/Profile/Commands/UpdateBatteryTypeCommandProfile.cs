using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class UpdateBatteryTypeCommandProfile : Profile
{
    public UpdateBatteryTypeCommandProfile()
    {
        CreateMap<UpdateBatteryTypeCommand, BatteryType>()
           .ForMember(x => x.Translates, a => a.Ignore());
    }
}
