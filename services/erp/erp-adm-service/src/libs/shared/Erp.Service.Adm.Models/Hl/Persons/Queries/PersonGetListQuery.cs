using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class PersonGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<PersonBriefDto>>
{
}
