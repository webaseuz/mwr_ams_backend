using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Refuels;

public class CreateRefuelFileCommandProfile :
    Profile
{
    public CreateRefuelFileCommandProfile()
    {
        CreateMap<CreateRefuelFileCommand, RefuelFile>();
    }
}
