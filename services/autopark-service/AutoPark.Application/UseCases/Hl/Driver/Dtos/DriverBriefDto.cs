namespace AutoPark.Application.UseCases.Drivers;

public class DriverBriefDto
{
    public int Id { get; set; }
    public long PersonId { get; set; }
    public string PersonName { get; set; }
    public int BranchId { get; set; }
    public int OrganizationId { get; set; }
    public string BranchName { get; set; }
    public Guid UniqueCode { get; set; }
    public Guid? QrCodeRegistryId { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanView { get; set; }
}
