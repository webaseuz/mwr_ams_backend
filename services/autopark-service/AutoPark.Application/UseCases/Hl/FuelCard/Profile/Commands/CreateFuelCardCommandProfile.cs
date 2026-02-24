using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.FuelCards;

public class CreateFuelCardCommandProfile :
    Profile
{
    public CreateFuelCardCommandProfile()
    {
        CreateMap<CreateFuelCardCommand, FuelCard>()
            .ForMember(src => src.ExpireAt, conf => conf.Ignore());
    }
}
