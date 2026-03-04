using MediatR;

namespace Erp.Service.Adm.Models;

public class LiquidTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
