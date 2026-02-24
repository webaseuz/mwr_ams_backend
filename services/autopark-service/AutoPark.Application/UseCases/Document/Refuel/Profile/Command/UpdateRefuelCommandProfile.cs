using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Refuels;

public class UpdateRefuelCommandProfile : Profile
{
    public UpdateRefuelCommandProfile()
    {
        CreateMap<UpdateRefuelCommand, Refuel>()
            .ForMember(src => src.Files, conf => conf.Ignore());
    }
}
