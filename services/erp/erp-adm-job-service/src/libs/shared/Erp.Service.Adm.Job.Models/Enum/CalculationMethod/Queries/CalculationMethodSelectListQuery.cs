using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CalculationMethodSelectListQuery : IRequest<WbSelectList<int>>
{
}
