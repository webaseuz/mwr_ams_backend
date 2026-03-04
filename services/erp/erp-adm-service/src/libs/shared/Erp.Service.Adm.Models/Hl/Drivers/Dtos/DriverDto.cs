namespace Erp.Service.Adm.Models;

public class DriverDto
{
    public int Id { get; set; }
    public long PersonId { get; set; }
    public string Inn { get; set; }
    public string Pinfl { get; set; }
    public string PersonName { get; set; }
    public int BranchId { get; set; }
    public int OrganizationId { get; set; }
    public string BranchName { get; set; }
    public Guid UniqueCode { get; set; }
    public Guid? QrCodeRegistryId { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public List<DriverDocumentDto> Documents { get; set; } = new();
}
