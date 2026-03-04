using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportCreateCommand : IRequest<WbHaveId<int>>
{
    public string OrderCode { get; set; }
    public int BranchId { get; set; }
    public int? DepartmentId { get; set; }
    public int TransportModelId { get; set; }
    public int TransportUseTypeId { get; set; }
    public int TransportBrandId { get; set; }
    public int TransportColorId { get; set; }
    public DateTime ManufacturedAt { get; set; }
    public DateTime PurchasedAt { get; set; }
    public string StateCode { get; set; } = null!;
    public string StateNumber { get; set; } = null!;
    public string VinNumber { get; set; } = null!;
    public decimal PurchasedAmount { get; set; }
    public int AmortizationPeriod { get; set; }
    public List<TransportFileDto> Files { get; set; } = new();
}
