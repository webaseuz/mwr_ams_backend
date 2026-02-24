using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Branches;

public class CreateBranchCommand :
        IRequest<IHaveId<int>>
{
    public string UniqueCode { get; set; } = null!;
    public int? ParentId { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int OrganizationId { get; set; }
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public string Address { get; set; } = null!;
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}
