using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class CreateRefuelCommand :
    IRequest<IHaveId<long>>
{
    public DateTime DocDate { get; set; }
    public int? BranchId { get; set; }
    public int FuelCardId { get; set; }
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int FuelTypeId { get; set; }
    public decimal Litre { get; set; }
    public decimal LitrePrice { get; set; }
    public string ChequeNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Message { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public List<CreateRefuelFileCommand> Files { get; set; } = new();
}
