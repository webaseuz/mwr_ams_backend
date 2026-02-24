using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class GetBranchSelectListQuery :
    IRequest<SelectList<int>>
{
    public int? RegionId { get; set; }
    public int? OrganizationId { get; set; }
}

