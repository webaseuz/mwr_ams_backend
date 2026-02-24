using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class AcceptSpareMovementCommand :
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}

