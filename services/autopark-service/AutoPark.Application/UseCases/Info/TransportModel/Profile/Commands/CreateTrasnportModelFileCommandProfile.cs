using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class CreateTrasnportModelFileCommandProfile : Profile
{
    public CreateTrasnportModelFileCommandProfile()
    {
        CreateMap<CreateTransportModelFileCommand, TransportModelFile>()
            .ForMember(dest => dest.TransportColorId, opt => opt.MapFrom(src => src.TransportColorId));
    }
}
