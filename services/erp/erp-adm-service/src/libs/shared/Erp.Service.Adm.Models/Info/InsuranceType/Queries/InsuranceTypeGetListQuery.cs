using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class InsuranceTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<InsuranceTypeBriefDto>>
{
    public int StateId { get; set; }
}
