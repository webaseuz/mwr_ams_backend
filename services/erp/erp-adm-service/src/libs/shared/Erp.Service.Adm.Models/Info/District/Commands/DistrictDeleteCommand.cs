using MediatR;

namespace Erp.Service.Adm.Models;

public class DistrictDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
