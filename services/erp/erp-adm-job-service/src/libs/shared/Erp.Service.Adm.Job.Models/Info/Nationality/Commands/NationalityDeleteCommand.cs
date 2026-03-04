using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class NationalityDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
