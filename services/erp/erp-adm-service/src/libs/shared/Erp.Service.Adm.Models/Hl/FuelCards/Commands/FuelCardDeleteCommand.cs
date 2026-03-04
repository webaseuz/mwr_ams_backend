using MediatR;

namespace Erp.Service.Adm.Models;

public class FuelCardDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
