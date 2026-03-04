using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class UnitOfMeasureSelectListQuery : IRequest<WbSelectList<int, UnitOfMeasureSelectListDto>>
{
}
