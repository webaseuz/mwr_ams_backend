using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TireSizes;

public class CreateTireSizeCommandProfile : Profile
{
    public CreateTireSizeCommandProfile()
    {
        CreateMap<CreateTireSizeCommand, TireSize>();
    }
}
