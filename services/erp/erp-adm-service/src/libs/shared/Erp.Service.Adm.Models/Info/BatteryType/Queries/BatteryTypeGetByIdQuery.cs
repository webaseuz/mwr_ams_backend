using MediatR;

namespace Erp.Service.Adm.Models;

public class BatteryTypeGetByIdQuery : IRequest<BatteryTypeDto>
{
    public int Id { get; set; }
}
