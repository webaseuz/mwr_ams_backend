using MediatR;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class GetPresentTrackingInfoByIdQuery :
    IRequest<PresentTrackingInfoDto>
{
    public long Id { get; set; }
}
