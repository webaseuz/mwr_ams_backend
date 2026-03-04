using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;

public class FixedMinimumValueSelectListQuery : IRequest<WbSelectList<int, FixedMinimumValueSelectListDto>>
{
    public int? MinimumValueTypeId { get; set; }
    public DateTime? DateOn { get; set; }

}
