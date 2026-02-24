using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Refuels;

public class UpdateRefuelFileCommandProfile :
    Profile
{
    public UpdateRefuelFileCommandProfile()
    {
        CreateMap<UpdateRefuelFileCommand, RefuelFile>();
    }
}
