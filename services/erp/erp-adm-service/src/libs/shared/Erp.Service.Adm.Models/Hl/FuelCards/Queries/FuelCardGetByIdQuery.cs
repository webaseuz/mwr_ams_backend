using MediatR;

namespace Erp.Service.Adm.Models;

public class FuelCardGetByIdQuery : IRequest<FuelCardDto>
{
    public int Id { get; set; }
}
