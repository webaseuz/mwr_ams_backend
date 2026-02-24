using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class CreatePresentTrackingInfoCommand :
    IRequest<SuccessResult<bool>>
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
