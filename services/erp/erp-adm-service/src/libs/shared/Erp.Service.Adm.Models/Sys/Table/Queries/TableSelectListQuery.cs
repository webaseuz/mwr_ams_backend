using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class TableSelectListQuery : IRequest<WbSelectList<int, TableSelectListDto>>
{
}
