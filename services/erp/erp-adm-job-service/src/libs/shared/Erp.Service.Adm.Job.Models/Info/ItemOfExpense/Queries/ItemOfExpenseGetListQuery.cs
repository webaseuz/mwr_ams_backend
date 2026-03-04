using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<ItemOfExpenseBriefDto>>
{
    public int StateId { get; set; }
}

