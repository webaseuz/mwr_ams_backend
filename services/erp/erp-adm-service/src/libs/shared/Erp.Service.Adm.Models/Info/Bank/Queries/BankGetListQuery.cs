using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class BankGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<BankBriefDto>>
{
    public int StateId { get; set; }
}
