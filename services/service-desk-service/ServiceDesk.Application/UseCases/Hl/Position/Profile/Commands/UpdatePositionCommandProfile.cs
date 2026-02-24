using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class UpdatePositionCommandProfile :
    Profile
{
    public UpdatePositionCommandProfile()
    {
        CreateMap<UpdatePositionCommand, Position>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
