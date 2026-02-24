using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Transports;

public class TransportBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public int OrganizationId { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; } = null!;
    public int? DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public Guid UniqueCode { get; set; }
    public int TransportModelId { get; set; }
    public string TransportModelName { get; set; } = null!;
    public int TransportUseTypeId { get; set; }
    public string TransportUseTypeName { get; set; } = null!;
    public int TransportBrandId { get; set; }
    public string TransportBrandName { get; set; } = null!;
    public int TransportColorId { get; set; }
    public string TransportColorName { get; set; } = null!;
    public DateTime ManufacturedAt { get; set; }
    public DateTime PurchasedAt { get; set; }
    public string StateCode { get; set; } = null!;
    public string StateNumber { get; set; } = null!;
    public string VinNumber { get; set; } = null!;
    public decimal PurchasedAmount { get; set; }
    public int AmortizationPeriod { get; set; }
    public Guid? QrCodeRegistryId { get; set; }
    public QrCodeRegistry QrCodeRegistry { get; set; }
    public string StateName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public bool CanModify { get; set; }
    public bool CanDelete { get; set; }
    public bool CanView { get; set; }
}
