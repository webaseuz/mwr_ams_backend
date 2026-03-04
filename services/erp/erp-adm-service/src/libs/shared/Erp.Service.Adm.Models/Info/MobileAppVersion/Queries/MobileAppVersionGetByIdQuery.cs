using MediatR;

namespace Erp.Service.Adm.Models;

public class MobileAppVersionGetByIdQuery : IRequest<MobileAppVersionDto>
{
    public Guid Id { get; set; }
}
