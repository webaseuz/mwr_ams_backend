using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Refuels;

public class RefuelFileDtoProfile :
    Profile
{
    public RefuelFileDtoProfile()
    {
        CreateMap<RefuelFile, RefuelFileDto>();
    }
}
