using MediatR;

namespace AutoPark.Application.UseCases.DriverPenalties;

public class GetDriverPenaltyByIdQuery
    : IRequest<DriverPenaltyDto>
{
    public long Id { get; set; }
}