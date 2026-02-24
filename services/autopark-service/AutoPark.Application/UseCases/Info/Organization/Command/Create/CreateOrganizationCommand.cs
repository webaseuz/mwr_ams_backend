using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Organizations;

public class CreateOrganizationCommand :
    IRequest<IHaveId<int>>
{
    public int? ParentId { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Inn { get; set; }
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public int? DistrictId { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Director { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public List<OrganizationTranslateCommand> Translates { get; set; } = new();
}