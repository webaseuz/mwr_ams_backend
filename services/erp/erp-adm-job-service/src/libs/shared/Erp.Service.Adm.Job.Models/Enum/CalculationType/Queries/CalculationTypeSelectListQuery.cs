using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CalculationTypeSelectListQuery : IRequest<WbSelectList<int, CalculationTypeSelectListDto>>
{
}
