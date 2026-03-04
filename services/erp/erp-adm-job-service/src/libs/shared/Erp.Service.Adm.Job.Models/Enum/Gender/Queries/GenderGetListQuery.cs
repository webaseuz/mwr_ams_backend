using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class GenderGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<GenderBriefDto>>
{ }
