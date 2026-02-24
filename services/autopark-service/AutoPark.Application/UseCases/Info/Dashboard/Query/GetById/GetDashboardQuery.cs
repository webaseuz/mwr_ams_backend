using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetDashboardQuery :
    IRequest<DashboardDto>
{
    public int? BranchId { get; set; }
}
