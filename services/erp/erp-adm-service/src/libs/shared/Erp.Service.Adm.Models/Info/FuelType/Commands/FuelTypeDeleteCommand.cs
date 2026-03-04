using MediatR;

namespace Erp.Service.Adm.Models;

public class FuelTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
