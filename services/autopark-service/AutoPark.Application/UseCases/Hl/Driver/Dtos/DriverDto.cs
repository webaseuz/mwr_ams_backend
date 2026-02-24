using AutoPark.Application.UseCases.Persons;

namespace AutoPark.Application.UseCases.Drivers;

public class DriverDto
{
    public int Id { get; set; }
    public long PersonId { get; set; }
    public string Inn { get; set; } = null!;
    public string Pinfl { get; set; } = null!;
    public string PersonName { get; set; } = null!;
    public int BranchId { get; set; }
    public int OrganizationId { get; set; }
    public string BranchName { get; set; } = null!;
    public Guid UniqueCode { get; set; }
    public Guid? QrCodeRegistryId { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public bool CanCreateForAllBranch { get; set; }
    public List<DriverDocumentDto> Documents { get; set; } = new();
    public PersonDto Person { get; set; }
}