using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class GetSpareMovementByIdQuery :
    IRequest<SpareMovementDto>
{
    public long Id { get; set; }
}
