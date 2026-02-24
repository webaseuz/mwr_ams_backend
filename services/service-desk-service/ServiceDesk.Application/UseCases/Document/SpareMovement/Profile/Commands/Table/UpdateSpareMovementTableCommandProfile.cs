using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class UpdateSpareMovementTableCommandProfile : Profile
{
    public UpdateSpareMovementTableCommandProfile()
    {
        CreateMap<UpdateSpareMovementTableCommand, SpareMovementTable>();
    }
}
