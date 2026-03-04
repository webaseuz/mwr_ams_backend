using MediatR;

namespace Erp.Service.Adm.Models;

public class FuelTypeGetByIdQuery : IRequest<FuelTypeDto>
{
    public int Id { get; set; }
}
