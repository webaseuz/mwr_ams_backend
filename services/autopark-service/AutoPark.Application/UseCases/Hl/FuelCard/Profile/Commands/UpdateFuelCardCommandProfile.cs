using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.FuelCards;

public class UpdateFuelCardCommandProfile :
    Profile
{
    public UpdateFuelCardCommandProfile()
    {
        CreateMap<UpdateFuelCardCommand, FuelCard>()
               .ForMember(src => src.ExpireAt, conf => conf.Ignore());
    }
}
