using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class DeleteSpareMovementCommand :
    IRequest<SuccessResult<bool>>
{
    public long Id { get; set; }
}
