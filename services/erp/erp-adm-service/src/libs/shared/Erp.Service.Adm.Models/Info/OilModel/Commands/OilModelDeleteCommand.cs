using MediatR;

namespace Erp.Service.Adm.Models;

public class OilModelDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
