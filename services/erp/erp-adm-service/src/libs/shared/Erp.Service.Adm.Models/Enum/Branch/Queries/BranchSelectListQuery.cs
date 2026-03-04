using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class BranchSelectListQuery : IRequest<WbSelectList<int>>
{
    public int? RegionId { get; set; }
    public int? OrganizationId { get; set; }
}