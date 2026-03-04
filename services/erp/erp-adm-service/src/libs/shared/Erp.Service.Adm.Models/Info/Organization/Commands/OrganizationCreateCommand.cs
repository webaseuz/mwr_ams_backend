using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class OrganizationCreateCommand : IRequest<WbHaveId<int>>
{
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string? Inn { get; set; }
    public int? ParentId { get; set; }
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public int? DistrictId { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public int? OkedId { get; set; }
    public string? Director { get; set; }
    public string? VatCode { get; set; }
    public string? ZipCode { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public int StateId { get; set; }
    public List<OrganizationTranslateCreateUpdateCommand> Translates { get; set; } = new();
}
