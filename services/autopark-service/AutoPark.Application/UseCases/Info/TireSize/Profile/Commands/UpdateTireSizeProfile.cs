using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TireSizes;

public class UpdateTireSizeProfile : Profile
{
    public UpdateTireSizeProfile()
    {
        CreateMap<UpdateTireSizeCommand, TireSize>();
    }
}
