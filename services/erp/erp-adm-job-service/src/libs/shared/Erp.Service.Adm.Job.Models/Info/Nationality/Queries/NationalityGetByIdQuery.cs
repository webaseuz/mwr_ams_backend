using MediatR;

namespace Erp.Service.Adm.Job.Models;
public class NationalityGetByIdQuery : IRequest<NationalityDto>
{
    public int Id { get; set; }
}
