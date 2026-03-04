using MediatR;

namespace Erp.Service.Adm.Models;

public class RegionDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
