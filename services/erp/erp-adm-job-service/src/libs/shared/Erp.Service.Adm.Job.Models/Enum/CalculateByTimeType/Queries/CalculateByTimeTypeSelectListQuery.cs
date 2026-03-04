using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CalculateByTimeTypeSelectListQuery : IRequest<WbSelectList<int>>
{
}
