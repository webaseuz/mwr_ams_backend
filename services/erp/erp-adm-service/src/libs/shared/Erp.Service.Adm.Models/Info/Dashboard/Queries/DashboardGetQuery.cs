using MediatR;

namespace Erp.Service.Adm.Models;

public class DashboardGetQuery : IRequest<DashboardDto>
{
    public int? BranchId { get; set; }
}
