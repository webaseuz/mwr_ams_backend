using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class CreateSpareMovementCommandProfile :
	Profile
{
    public CreateSpareMovementCommandProfile()
    {
        CreateMap<CreateSpareMovementCommand, SpareMovement>()
            .ForMember(src => src.Tables, conf => conf.Ignore());
    }
}
