using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.MobileAppVersions;

public class UpdateMobileAppVersionCommand :
    IHaveIdProp<Guid>,
    IRequest<IHaveId<Guid>>
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = null!;
    public string VersionCode { get; set; } = null!;
    public string Details { get; set; } = null!;
    public DateTime ReleaseAt { get; set; }
}
