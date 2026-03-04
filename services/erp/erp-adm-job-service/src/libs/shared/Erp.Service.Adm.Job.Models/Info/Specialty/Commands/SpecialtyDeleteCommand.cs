using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class SpecialtyDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
