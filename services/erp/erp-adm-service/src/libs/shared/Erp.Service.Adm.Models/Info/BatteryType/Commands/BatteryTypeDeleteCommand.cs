using MediatR;

namespace Erp.Service.Adm.Models;

public class BatteryTypeDeleteCommand : IRequest<bool>
{
    public int Id { get; set; }
}
