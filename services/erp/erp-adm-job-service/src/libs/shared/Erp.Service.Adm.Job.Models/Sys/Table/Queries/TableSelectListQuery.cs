using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class TableSelectListQuery : IRequest<WbSelectList<int, TableSelectListDto>>
{
}
