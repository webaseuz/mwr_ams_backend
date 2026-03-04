using MediatR;

namespace Erp.Service.Adm.Models;

public class DriverGetByIdQuery : IRequest<DriverDto>
{
    public int Id { get; set; }
}
