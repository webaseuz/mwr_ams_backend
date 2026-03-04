using MediatR;

namespace Erp.Service.Adm.Models;

public class DriverPenaltyGetByIdQuery : IRequest<DriverPenaltyDto>
{
    public long Id { get; set; }
}
