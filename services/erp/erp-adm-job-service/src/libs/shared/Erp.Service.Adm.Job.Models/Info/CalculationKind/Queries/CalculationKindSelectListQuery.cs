using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class CalculationKindSelectListQuery : IRequest<WbSelectList<int>>
{
}
