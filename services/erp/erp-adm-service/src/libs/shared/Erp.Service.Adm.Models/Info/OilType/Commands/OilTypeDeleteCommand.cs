using MediatR;

namespace Erp.Service.Adm.Models;

public class OilTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
