using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.FuelTypes;

public class FuelTypeTranslateCommandProfile : Profile
{
    public FuelTypeTranslateCommandProfile()
    {
        CreateMap<FuelTypeTranslateCommand, FuelTypeTranslate>();
    }
}
