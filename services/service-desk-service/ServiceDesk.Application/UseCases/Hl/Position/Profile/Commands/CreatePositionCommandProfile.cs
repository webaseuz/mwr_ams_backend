using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class CreatePositionCommandProfile :
    Profile
{
    public CreatePositionCommandProfile()
    {
        CreateMap<CreatePositionCommand, Position>()
            .ForMember(src => src.Translates, conf => conf.Ignore());

    }
}
