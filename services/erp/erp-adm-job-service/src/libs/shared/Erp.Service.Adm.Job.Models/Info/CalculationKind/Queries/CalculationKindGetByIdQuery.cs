using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class CalculationKindGetByIdQuery : IRequest<CalculationKindDto>
{
    public int Id { get; set; }
}
