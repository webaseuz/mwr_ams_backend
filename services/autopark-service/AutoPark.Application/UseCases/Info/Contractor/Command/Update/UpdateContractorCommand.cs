using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.Contractors;

public class UpdateContractorCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int CountryId { get; set; }
    public int RegionId { get; set; }
    public int DistrictId { get; set; }
    public int? BankId { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string ContactInfo { get; set; }
    public string Inn { get; set; } = null!;
    public string Accounter { get; set; }
    public string Director { get; set; }
    public string VatCode { get; set; }
    public int StateId { get; set; }
}
