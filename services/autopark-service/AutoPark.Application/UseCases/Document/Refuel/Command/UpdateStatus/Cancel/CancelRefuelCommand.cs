using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class CancelRefuelCommand :
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
}
