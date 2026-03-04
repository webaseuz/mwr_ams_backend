using MediatR;

namespace Erp.Service.Adm.Models;

public class PositionGetByIdQuery : IRequest<PositionDto>
{
    public int Id { get; set; }
}
