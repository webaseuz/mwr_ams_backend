using Erp.Core;
using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class CalculationKindTranslateCommand : TranslateCommand, IRequest<WbHaveId<int>>
{
}
