using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class GetSpareMovementQuery :
    IRequest<SpareMovementDto>
{ }