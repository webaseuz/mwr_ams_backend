using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class CalculationKindDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
