using MediatR;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class GetPresentTrackingInfoQuery :
    IRequest<PresentTrackingInfoDto>
{ }
