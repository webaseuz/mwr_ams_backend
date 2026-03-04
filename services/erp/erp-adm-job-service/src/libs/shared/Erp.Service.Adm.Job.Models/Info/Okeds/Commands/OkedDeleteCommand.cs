using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class OkedDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
