using MediatR;

namespace Erp.Service.Adm.Models;

public class TireSizeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
