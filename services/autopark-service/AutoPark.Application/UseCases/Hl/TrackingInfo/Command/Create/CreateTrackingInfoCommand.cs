using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class CreateTrackingInfoCommand :
    IRequest<SuccessResult<bool>>
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public long PersonId { get; set; }
    public DateTime DateAt { get; set; }
}
