using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class GenderGetByIdQuery : IRequest<GenderDto>
{
    public int Id { get; set; }
}
