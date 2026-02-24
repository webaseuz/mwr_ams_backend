using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class RevokeSpareMovementCommand :
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}