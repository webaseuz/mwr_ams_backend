using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class EduDirectionDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
