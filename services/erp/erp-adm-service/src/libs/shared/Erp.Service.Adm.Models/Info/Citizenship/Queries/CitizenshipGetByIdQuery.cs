using MediatR;

namespace Erp.Service.Adm.Models;

public class CitizenshipGetByIdQuery : IRequest<CitizenshipDto>
{
    public int Id { get; set; }
}
