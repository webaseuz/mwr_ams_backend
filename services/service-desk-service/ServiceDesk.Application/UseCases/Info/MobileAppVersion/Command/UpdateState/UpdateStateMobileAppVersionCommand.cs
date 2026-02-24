using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class UpdateStateMobileAppVersionCommand :
    IHaveIdProp<Guid>,
    IRequest<IHaveId<Guid>>
{
    public Guid Id { get; set; }
    public int StateId { get; set; }
}
