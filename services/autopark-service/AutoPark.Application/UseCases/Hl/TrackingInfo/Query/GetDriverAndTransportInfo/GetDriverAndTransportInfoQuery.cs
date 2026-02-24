using AutoPark.Application.UseCases.PresentTrackingInfos;
using MediatR;


namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetDriverAndTransportInfoQuery :
    IRequest<DriverAndTransportInfoDto>
{
    public long PersonId { get; set; }
}
