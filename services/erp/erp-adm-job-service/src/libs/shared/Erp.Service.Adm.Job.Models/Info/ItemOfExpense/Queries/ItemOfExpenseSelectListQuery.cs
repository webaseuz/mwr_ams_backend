using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class ItemOfExpenseSelectListQuery : IRequest<WbSelectList<int, ItemOfExpenseSelectListDto>>
{
}

