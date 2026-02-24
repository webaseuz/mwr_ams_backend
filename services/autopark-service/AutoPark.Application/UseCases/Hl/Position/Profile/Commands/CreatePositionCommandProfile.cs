using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Positions;

public class CreatePositionCommandProfile :
    Profile
{
    public CreatePositionCommandProfile()
    {
        CreateMap<CreatePositionCommand, Position>()
            .ForMember(src => src.Translates, conf => conf.Ignore());

    }
}
