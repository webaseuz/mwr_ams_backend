using MediatR;
using WEBASE.Salary.Core.Model;

namespace Erp.Service.Adm.Job.Models;

public class GetAllCalculationKindCoreCommand : IRequest<List<CalculationKindCore>>
{
    public DateTime? DateOn { get; set; }
}
