using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class FuelTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<FuelTypeBriefDto>>
{
    public int StateId { get; set; }
}
