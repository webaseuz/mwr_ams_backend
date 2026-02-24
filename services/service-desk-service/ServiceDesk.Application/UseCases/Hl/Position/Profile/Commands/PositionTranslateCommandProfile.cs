using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class PositionTranslateCommandProfile :
    Profile
{
    public PositionTranslateCommandProfile()
    {
        CreateMap<PositionTranslateCommand, PositionTranslate>();
    }
}
