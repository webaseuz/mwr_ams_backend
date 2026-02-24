using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Positions;

public class UpdatePositionCommandProfile :
    Profile
{
    public UpdatePositionCommandProfile()
    {
        CreateMap<UpdatePositionCommand, Position>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
