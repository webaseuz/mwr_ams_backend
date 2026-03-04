using MediatR;

namespace Erp.Service.Adm.Models;

public class PositionDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
