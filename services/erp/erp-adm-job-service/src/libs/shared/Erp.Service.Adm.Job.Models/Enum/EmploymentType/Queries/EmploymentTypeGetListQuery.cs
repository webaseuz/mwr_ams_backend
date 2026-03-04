using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class EmploymentTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<EmploymentTypeBriefDto>>
{
}
