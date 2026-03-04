using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DriverSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public long? TransportSettingId { get; set; }
}