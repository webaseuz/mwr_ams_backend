using MediatR;

namespace Erp.Service.Adm.Models;
public class StatusGetByIdQuery : IRequest<StatusDto>
{
    public int Id { get; set; }
}
