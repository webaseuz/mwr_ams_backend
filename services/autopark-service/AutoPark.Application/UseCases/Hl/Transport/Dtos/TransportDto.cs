namespace AutoPark.Application.UseCases.Transports;

public class TransportDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public int OrganizationId { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public int? DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public Guid UniqueCode { get; set; }
    public int TransportModelId { get; set; }
    public string TransportModelName { get; set; }
    public int TransportUseTypeId { get; set; }
    public string TransportUseTypeName { get; set; }
    public int TransportBrandId { get; set; }
    public string TransportBrandName { get; set; }
    public int TransportColorId { get; set; }
    public string TransportColorName { get; set; }
    public DateTime ManufacturedAt { get; set; }
    public DateTime PurchasedAt { get; set; }
    public string StateCode { get; set; } = null!;
    public string StateNumber { get; set; } = null!;
    public string VinNumber { get; set; } = null!;
    public decimal PurchasedAmount { get; set; }
    public int AmortizationPeriod { get; set; }
    public Guid? QrCodeRegistryId { get; set; }
    public string QrCodeRegistryName { get; set; }
    public string StateName { get; set; } = null!;
    public bool CanCreateForAllBranch { get; set; }
    //public List<TransportFileDto> Files { get; set; } = new();
}
