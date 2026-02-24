using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class CreateSpareMovementTableCommandProfile : Profile
{
    public CreateSpareMovementTableCommandProfile()
    {
        CreateMap<CreateSpareMovementTableCommand, SpareMovementTable>();
    }
}
