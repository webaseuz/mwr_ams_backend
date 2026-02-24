using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Positions;

public class PositionTranslateCommandProfile :
    Profile
{
    public PositionTranslateCommandProfile()
    {
        CreateMap<PositionTranslateCommand, PositionTranslate>();
    }
}
