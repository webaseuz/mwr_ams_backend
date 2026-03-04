using MediatR;

namespace Erp.Service.Adm.Models;

public class TransportSettingGetByIdQuery : IRequest<TransportSettingDto>
{
    public long Id { get; set; }
}
