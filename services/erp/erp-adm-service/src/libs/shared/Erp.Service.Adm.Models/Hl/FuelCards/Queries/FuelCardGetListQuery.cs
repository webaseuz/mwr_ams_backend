using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class FuelCardGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<FuelCardBriefDto>>
{
    public int? DriverId { get; set; }
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? PlasticCardTypeId { get; set; }
    public string CardNumber { get; set; }
}
