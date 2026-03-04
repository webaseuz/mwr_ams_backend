using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class SpecialtyGetByIdQuery : IRequest<SpecialtyDto>
{
    public int Id { get; set; }
}
