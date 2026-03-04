using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? BranchId { get; set; }
    public int? DriverId { get; set; }
    public bool? FromSetting { get; set; }
}