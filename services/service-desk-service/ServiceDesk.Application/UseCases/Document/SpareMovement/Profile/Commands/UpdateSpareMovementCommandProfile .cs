using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class UpdateSpareMovementCommandProfile :
	Profile
{
    public UpdateSpareMovementCommandProfile()
    {
        CreateMap<UpdateSpareMovementCommand, SpareMovement>()
            .ForMember(src => src.Tables, conf => conf.Ignore());
    }
}
