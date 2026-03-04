using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class MobileAppVersionCreateCommand : IRequest<WbHaveId<Guid>>
{
    public string FileName { get; set; }
    public string VersionCode { get; set; }
    public string Details { get; set; }
    public DateTime ReleaseAt { get; set; }
    public int StateId { get; set; }
}
