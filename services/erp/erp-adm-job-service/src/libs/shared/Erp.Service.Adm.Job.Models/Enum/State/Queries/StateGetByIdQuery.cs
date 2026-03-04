using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class StateGetByIdQuery : IRequest<StateDto>
{
    public int Id { get; set; }
}
