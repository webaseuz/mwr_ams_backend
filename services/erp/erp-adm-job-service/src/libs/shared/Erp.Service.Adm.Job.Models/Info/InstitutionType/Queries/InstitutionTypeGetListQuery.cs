using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class InstitutionTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<InstitutionTypeBriefDto>>
{
    public int StateId { get; set; }
}

