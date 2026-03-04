using MediatR;

namespace Erp.Service.Adm.Models;

public class DriverDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
