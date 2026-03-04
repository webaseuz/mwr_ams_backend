using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class BankGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<BankBriefDto>>
{
    public int StateId { get; set; }
}
