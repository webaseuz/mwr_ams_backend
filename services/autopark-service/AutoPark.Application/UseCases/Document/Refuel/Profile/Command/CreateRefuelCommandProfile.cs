using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Refuels;

public class CreateRefuelCommandProfile : Profile
{
    public CreateRefuelCommandProfile()
    {
        CreateMap<CreateRefuelCommand, Refuel>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
