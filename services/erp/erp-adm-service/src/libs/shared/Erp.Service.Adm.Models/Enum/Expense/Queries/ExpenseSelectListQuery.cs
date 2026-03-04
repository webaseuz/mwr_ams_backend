using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class ExpenseSelectListQuery : IRequest<WbSelectList<long>>
{
}