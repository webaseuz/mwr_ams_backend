using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class EduYearDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
