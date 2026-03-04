using MediatR;

namespace Erp.Service.Adm.Models;

public class NationalityGetByIdQuery : IRequest<NationalityDto>
{
    public int Id { get; set; }
}
