using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.FuelTypes;

public class UpdateFuelTypeCommandProfile : Profile
{
    public UpdateFuelTypeCommandProfile()
    {
        CreateMap<UpdateFuelTypeCommand, FuelType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
