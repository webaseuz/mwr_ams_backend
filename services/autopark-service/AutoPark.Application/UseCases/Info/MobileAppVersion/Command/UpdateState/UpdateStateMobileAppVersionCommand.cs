using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class UpdateStateMobileAppVersionCommand :
    IHaveIdProp<Guid>,
    IRequest<IHaveId<Guid>>
{
    public Guid Id { get; set; }
    public int StateId { get; set; }
}
