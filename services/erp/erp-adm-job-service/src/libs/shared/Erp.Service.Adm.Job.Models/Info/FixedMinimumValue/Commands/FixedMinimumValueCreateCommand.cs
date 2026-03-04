using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class FixedMinimumValueCreateCommand : IRequest<WbHaveId<int>>
{
    public int MinimumValueTypeId { get; set; }
    public DateTime DateOn { get; set; }
    public decimal FixedAmount { get; set; }
    public decimal ChangePercentage { get; set; }
    public string NormativeDoc { get; set; }
    public int StateId { get; set; }

}

