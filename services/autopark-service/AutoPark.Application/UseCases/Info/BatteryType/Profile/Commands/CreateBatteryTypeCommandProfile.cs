using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class CreateBatteryTypeCommandProfile : Profile
{
    public CreateBatteryTypeCommandProfile()
    {
        CreateMap<CreateBatteryTypeCommand, BatteryType>()
            .ForMember(x => x.Translates, a => a.Ignore());
    }
}
