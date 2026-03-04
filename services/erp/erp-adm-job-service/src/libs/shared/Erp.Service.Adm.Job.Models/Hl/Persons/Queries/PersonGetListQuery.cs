using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class PersonGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<PersonBriefDto>>
{
}
