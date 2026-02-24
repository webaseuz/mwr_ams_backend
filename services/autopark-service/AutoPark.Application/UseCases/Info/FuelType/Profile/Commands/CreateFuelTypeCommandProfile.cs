using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.FuelTypes;

public class CreateFuelTypeCommandProfile : Profile
{
    public CreateFuelTypeCommandProfile()
    {
        CreateMap<CreateFuelTypeCommand, FuelType>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
