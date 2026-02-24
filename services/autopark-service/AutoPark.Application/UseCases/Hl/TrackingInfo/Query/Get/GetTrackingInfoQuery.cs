using MediatR;
namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetTrackingInfoQuery :
    IRequest<TrackingInfoDto>
{ }
